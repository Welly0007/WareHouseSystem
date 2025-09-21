using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<CreateCategoryDto, Category>();
			CreateMap<Category, ViewCategoryDto>();
		}
	}
}
