using AutoMapper;
using DomainLayer.Models.WarehouseModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class InventoryTransactionProfile : Profile
	{
		public InventoryTransactionProfile()
		{
			CreateMap<CreateInventoryTransactionDto, InventoryTransaction>();
			
			CreateMap<InventoryTransaction, ViewInventoryTransactionDto>()
				.ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()))
				.ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Product.Name))
				.ForMember(d => d.WarehouseName, opt => opt.MapFrom(s => s.Warehouse.Name))
				.ForMember(d => d.CreatedByName, opt => opt.MapFrom(s => s.CreatedBy.Name));
		}
	}
}