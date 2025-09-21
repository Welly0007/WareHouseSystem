using AutoMapper;
using DomainLayer.Models.Parties;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Service.Mappers.PartiesMapper
{
	public class InvoiceProfile : Profile
	{
		public InvoiceProfile()
		{
			CreateMap<CreateInvoiceDto, Invoice>();
			CreateMap<Invoice, ViewInvoiceDto>()
				.ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name))
				.ForMember(d => d.SupplierName, opt => opt.MapFrom(s => s.Supplier.Name))
				.ForMember(d => d.CreatedByName, opt => opt.MapFrom(s => s.CreatedBy.Name));
		}
	}
}