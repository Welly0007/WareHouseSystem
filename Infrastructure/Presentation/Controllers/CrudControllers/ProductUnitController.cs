using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductUnitController : GenericController<ProductUnit, CreateProductUnitDto, ViewProductUnitDto, string>
	{
		public ProductUnitController(IGenericService<ProductUnit, CreateProductUnitDto, ViewProductUnitDto, string> _service) : base(_service)
		{
		}
	}
}