using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos;

namespace Service.MappingProfiles
{
	public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<CreateProductDto, Product>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
		}
	}
}