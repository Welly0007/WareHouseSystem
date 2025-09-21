using AutoMapper;
using DomainLayer.Models.Parties;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Service.Mappers.PartiesMapper
{
	public class SupplierProfile : Profile
	{
		public SupplierProfile()
		{
			CreateMap<CreateSupplierDto, Supplier>();
			CreateMap<Supplier, ViewSupplierDto>();
		}
	}
}