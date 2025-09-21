using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InventoryTransactionController : GenericController<InventoryTransaction, CreateInventoryTransactionDto, ViewInventoryTransactionDto, string>
	{
		public InventoryTransactionController(InventoryService<InventoryTransaction, CreateInventoryTransactionDto, ViewInventoryTransactionDto, string> service) : base(service)
		{
		}
	}
}