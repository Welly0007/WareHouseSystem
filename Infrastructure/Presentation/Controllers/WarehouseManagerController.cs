using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.CrudControllers;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WarehouseManagerController : GenericController<Warehouse, CreateWarehouseDto, ViewWarehouseDto, string>
	{
		private readonly IServiceManager _serviceManager;
		public WarehouseManagerController(IGenericService<Warehouse, CreateWarehouseDto, ViewWarehouseDto, string> _service, IServiceManager serviceManager) : base(_service)
		{
			_serviceManager = serviceManager;
		}
		[HttpGet("GetDefectiveReports")]
		public async Task<ActionResult<PaginatedResult<ViewDefectiveDto>>> GetDefectiveReports([FromQuery] string? productId)
		{
			var result = await _serviceManager.ProductService.GetAllDefectiveProducts(productId);
			return Ok(result);
		}

		[HttpPost("RegisterDefective")]
		public async Task<ActionResult<ViewDefectiveDto>> RegisterDefectiveProducts(CreateDefectiveDto request)
		{
			var result = await _serviceManager.ProductService.RegisterDefectiveProduct(request);
			return Ok(result);
		}

		[HttpPut("TransferProducts")]
		public async Task<ActionResult<ProductsTransferResults>> TransferProducts(WarehouseProductsTransferRequest request)
		{
			var result = await _serviceManager.ProductService.TranferProductsToWarehouse(request);
			return Ok(result);
		}
	}
}
