using AutoMapper;
using DomainLayer.Models.Parties;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Service.Mappers.PartiesMapper
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			CreateMap<CreateCustomerDto, Customer>();
			CreateMap<Customer, ViewCustomerDto>();
		}
	}
}