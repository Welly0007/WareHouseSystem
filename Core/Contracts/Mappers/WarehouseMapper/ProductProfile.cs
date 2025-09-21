using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos;

namespace Service.Mappers.WarehouseMapper
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<CreateProductDto, Product>();

			CreateMap<Product, ViewProductDto>()
				.ForMember(d => d.WarehouseName, opt => opt.MapFrom(s => s.Warehouse.Name))
				.ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
				.ForMember(d => d.IsNearExpiry, opt => opt.MapFrom(s => s.IsNearExpiry()))
				.ForMember(d => d.IsExpired, opt => opt.MapFrom(s => s.IsExpired()))
				.ForMember(d => d.NearExpiryDate, opt => opt.MapFrom(s => s.Expirable ? s.GetNearExpiryDate() : (DateTime?)null));
		}
	}
}
