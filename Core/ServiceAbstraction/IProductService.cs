using Shared;
using Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;
using Shared.ProductSpecifications;

namespace ServiceAbstraction
{
	public interface IProductService
	{
		Task<PaginatedResult<ViewProductDto>?> GetAllProducts(ProductQueryParams queryParams);
		Task<ViewProductDto> GetProductById(string id);
		Task<ViewProductDto> CreateProductAsync(CreateProductDto createProductDto);
		Task<bool> DeleteProductAsync(string id);
		Task<ViewProductDto> UpdateProductAsync(string id, CreateProductDto updateProductDto);
		Task<ProductsTransferResults> TranferProductsToWarehouse(WarehouseProductsTransferRequest request);
		Task<ViewDefectiveDto> RegisterDefectiveProduct(CreateDefectiveDto createDefectiveDto);
		Task<PaginatedResult<ViewDefectiveDto>?> GetAllDefectiveProducts(string? productId);
	}
}
