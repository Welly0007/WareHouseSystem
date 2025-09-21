using AutoMapper;
using DomainLayer.Models.Parties;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Service.Mappers.PartiesMapper
{
	public class PaymentProfile : Profile
	{
		public PaymentProfile()
		{
			CreateMap<CreatePaymentDto, Payment>();
			CreateMap<Payment, ViewPaymentDto>()
				.ForMember(d => d.SupplierName, opt => opt.MapFrom(s => s.Supplier.Name));
		}
	}
}