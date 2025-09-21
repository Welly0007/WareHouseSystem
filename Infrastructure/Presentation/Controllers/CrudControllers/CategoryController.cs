using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : GenericController<Category, CreateCategoryDto, ViewCategoryDto, string>
	{
		public CategoryController(IGenericService<Category, CreateCategoryDto, ViewCategoryDto, string> _service) : base(_service)
		{
		}
	}
}
