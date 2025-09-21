using AutoMapper;
using DomainLayer.Models.WarehouseModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class ProductUnitProfile : Profile
	{
		public ProductUnitProfile()
		{
			CreateMap<CreateProductUnitDto, ProductUnit>();
			CreateMap<ProductUnit, ViewProductUnitDto>();
		}
	}
}