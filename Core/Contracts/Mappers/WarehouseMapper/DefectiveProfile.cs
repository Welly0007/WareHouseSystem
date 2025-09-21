using AutoMapper;
using DomainLayer.Models.WarehouseModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class DefectiveProfile : Profile
	{
		public DefectiveProfile()
		{
			CreateMap<CreateDefectiveDto, DefectiveReport>()
				.ForMember(d => d.ReportedAt, opt => opt.MapFrom(s => s.ReportedAt));

			CreateMap<DefectiveReport, ViewDefectiveDto>()
				.ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Product.Name))
				.ForMember(d => d.ProductCode, opt => opt.MapFrom(s => s.Product.Code))
				.ForMember(d => d.WarehouseName, opt => opt.MapFrom(s => s.wareHouse.Name))
				.ForMember(d => d.ReportedByName, opt => opt.MapFrom(s => s.ReportedBy.Name));
		}
	}
}