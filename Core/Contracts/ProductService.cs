using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models;
using DomainLayer.Models.UserModule;
using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Identity;
using Service.Specifications;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;
using Shared.ProductSpecifications;

namespace Service
{
	public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper, UserManager<User> userManager) : IProductService
	{
		public async Task<PaginatedResult<ViewProductDto>?> GetAllProducts(ProductQueryParams queryParams)
		{
			var repo = _unitOfWork.GetRepository<Product>();
			// I need here to set the specifaction for product, it will take queryParams as input
			var spec = new ProductSpecifications(queryParams);
			var totalFoundItems = await repo.CountAsync(spec);

			// then pass the spec to the repo method
			var products = await repo.GetAllAsync(spec);
			if (!products.Any())
			{
				throw new ProductNotFound("No products found with those parameters.");
			}

			//var products = await repo.GetAllAsync();
			var productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ViewProductDto>>(products);

			return new PaginatedResult<ViewProductDto>(queryParams.pageIndex, productDtos.Count(), totalFoundItems, productDtos);
		}

		public async Task<ViewProductDto> GetProductById(string id)
		{
			var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);
			if (product is null)
			{
				throw new ProductNotFound(id);
			}
			var productDto = _mapper.Map<Product, ViewProductDto>(product);
			return productDto;
		}
		public async Task<ViewProductDto> CreateProductAsync(CreateProductDto createProductDto)
		{
			var product = _mapper.Map<CreateProductDto, Product>(createProductDto);

			// Validate expirable products
			if (createProductDto.Expirable && createProductDto.ExpiryDate == null)
			{
				throw new CustomBadRequest("Product cannot be expirable without expiry date");
			}
			else if (createProductDto.Expirable && createProductDto.ExpiryDate.HasValue)
			{
				product.ExpiryDate = createProductDto.ExpiryDate.Value;
				product.Expirable = createProductDto.Expirable;
				product.NearExpireThreshold = createProductDto.NearExpireThreshold;
				product.DurationType = createProductDto.DurationType;
			}
			else
			{
				product.Expirable = false;
			}

			await _unitOfWork.GetRepository<Product>().AddAsync(product);
			await _unitOfWork.CompleteAsync();
			var productDto = _mapper.Map<Product, ViewProductDto>(product);
			return productDto;
		}

		public async Task<bool> DeleteProductAsync(string id)
		{
			var prpoductToBeDeleted = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);
			if (prpoductToBeDeleted is null)
			{
				throw new ProductNotFound(id);
			}
			_unitOfWork.GetRepository<Product>().Delete(prpoductToBeDeleted);
			await _unitOfWork.CompleteAsync();
			return true;
		}

		public async Task<ViewProductDto> UpdateProductAsync(string id, CreateProductDto updateProductDto)
		{
			var product = _unitOfWork.GetRepository<Product>().GetByIdAsync(id).Result;
			if (product is null)
			{
				throw new ProductNotFound(id);
			}
			_mapper.Map(updateProductDto, product);
			_unitOfWork.GetRepository<Product>().Update(product);
			await _unitOfWork.CompleteAsync();
			return _mapper.Map<Product, ViewProductDto>(product);
		}
		public async Task<ProductsTransferResults> TranferProductsToWarehouse(WarehouseProductsTransferRequest request)
		{
			var repo = _unitOfWork.GetRepository<Product>();
			var productIds = request.Products.SelectMany(dict => dict.Keys).ToList();
			var spec = new ProductSpecifications(productIds);
			var products = await repo.GetAllAsync(spec);
			var transferResults = new ProductsTransferResults();
			var transferRepo = _unitOfWork.GetRepository<InventoryTransaction>();
			var warehouseRepo = _unitOfWork.GetRepository<Warehouse>();
			if (await warehouseRepo.GetByIdAsync(request.SourceWarehouseId) is null)
			{
				throw new NotFoundException($"Warehouse with Id{request.SourceWarehouseId} doesn't exist");
			}
			if (await warehouseRepo.GetByIdAsync(request.DestinationWarehouseId) is null)
			{
				throw new NotFoundException($"Warehouse with Id{request.DestinationWarehouseId} doesn't exist");
			}
			foreach (var product in products)
			{
				if (product.WarehouseId == request.SourceWarehouseId)
				{
					product.WarehouseId = request.DestinationWarehouseId;
					transferResults.SuccessfulTransfers++;
				}
				else
				{
					transferResults.FailedTransfers++;
					transferResults.Messages.Add($"Product with ID {product.Id} is not in the source warehouse{request.SourceWarehouseId} and cannot be transferred.");
				}
			}
			if (transferResults.SuccessfulTransfers > 0)
			{
				await _unitOfWork.CompleteAsync();
			}
			return transferResults;
		}

		public async Task<ViewDefectiveDto> RegisterDefectiveProduct(CreateDefectiveDto createDefectiveDto)
		{
			if (createDefectiveDto is null)
			{
				throw new ArgumentNullException(nameof(createDefectiveDto), "requset couldn't be null");
			}
			var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(createDefectiveDto.ProductId);
			if (product is null)
			{
				throw new ProductNotFound(createDefectiveDto.ProductId);
			}
			var defectiveReport = _mapper.Map<CreateDefectiveDto, DefectiveReport>(createDefectiveDto);
			product.Quantity -= defectiveReport.Quantity;
			if (product.Quantity < 0)
			{
				throw new InvalidOperationException($"Insufficient stock for product ID {product.Id}. Cannot register defective items.");
			}
			defectiveReport.wareHouse = product.Warehouse;
			await _unitOfWork.GetRepository<DefectiveReport>().AddAsync(defectiveReport);
			_unitOfWork.GetRepository<Product>().Update(product);
			if (await userManager.FindByIdAsync(defectiveReport.ReportedById) is null)
			{
				throw new userNotFound("The user reporting the defective product doesn't exist");
			}
			await _unitOfWork.CompleteAsync();
			var defectiveDto = _mapper.Map<DefectiveReport, ViewDefectiveDto>(defectiveReport);
			return defectiveDto;
		}

		public async Task<PaginatedResult<ViewDefectiveDto>?> GetAllDefectiveProducts(string? productId)
		{
			var repo = _unitOfWork.GetRepository<DefectiveReport>();
			var defectiveReports = Enumerable.Empty<DefectiveReport>();

			if (productId is not null)
			{
				var spec = new DefectiveSpecification(productId);
				defectiveReports = await repo.GetAllAsync(spec);
			}
			else
			{
				defectiveReports = await repo.GetAllAsync();
			}
			if (!defectiveReports.Any())
			{
				throw new NotFoundException("No defective reports found.");
			}
			var defectiveDtos = _mapper.Map<IEnumerable<DefectiveReport>, IEnumerable<ViewDefectiveDto>>(defectiveReports);
			var result = new PaginatedResult<ViewDefectiveDto>(1, defectiveDtos.Count(), defectiveDtos.Count(), defectiveDtos);
			return result;
		}
	}
}
