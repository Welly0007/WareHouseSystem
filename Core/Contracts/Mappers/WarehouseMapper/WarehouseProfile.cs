using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class WarehouseProfile : Profile
	{
		public WarehouseProfile()
		{
			CreateMap<CreateWarehouseDto, Warehouse>();
			CreateMap<Warehouse, ViewWarehouseDto>();
		}

	}
}
