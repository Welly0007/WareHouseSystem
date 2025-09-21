using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using DomainLayer.Models.WarehouseModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service
{
	public class InventoryService<TEntity, TIn, TOut, Tkey> : GenericService<InventoryTransaction, CreateInventoryTransactionDto, ViewInventoryTransactionDto, string>
		where TEntity : BaseEntity
	{
		private readonly IMapper mapper;
		private readonly IUnitOfWork unitOfWork;
		public InventoryService(IUnitOfWork _unitOfWork, IMapper mapper) : base(_unitOfWork, mapper)
		{
			this.mapper = mapper;
			this.unitOfWork = _unitOfWork;
		}
		public override async Task<int> CreateAsync(CreateInventoryTransactionDto input)
		{
			if (input is null)
			{
				throw new ArgumentNullException(nameof(input), "Input entity cannot be null.");
			}
			var entity = mapper.Map<InventoryTransaction>(input);
			var productRepo = unitOfWork.GetRepository<Product>();
			var product = await productRepo.GetByIdAsync(input.ProductId);
			if (product is null)
			{
				throw new KeyNotFoundException($"Product with Id {input.ProductId} not found.");
			}
			if (input.Type == TransactionTypes.Import)
			{
				product.Quantity += input.Quantity;
			}
			else if (input.Type == TransactionTypes.Export)
			{
				if (product.Quantity < input.Quantity)
				{
					throw new InvalidOperationException("Insufficient product quantity for Exporting.");
				}
				product.Quantity -= input.Quantity;
			}
			else
			{
				throw new ArgumentException("Invalid transaction type. Must be 'Import' or 'Export'.");
			}
			productRepo.Update(product);
			await unitOfWork.GetRepository<InventoryTransaction>().AddAsync(entity);
			return await unitOfWork.CompleteAsync();
		}

	}
}
