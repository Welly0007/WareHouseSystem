using AutoMapper;
using DomainLayer.Models.Parties;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Service.Mappers.PartiesMapper
{
	public class ReceiptProfile : Profile
	{
		public ReceiptProfile()
		{
			CreateMap<CreateReceiptDto, Receipt>();
			CreateMap<Receipt, ViewReceiptDto>()
				.ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name));
		}
	}
}