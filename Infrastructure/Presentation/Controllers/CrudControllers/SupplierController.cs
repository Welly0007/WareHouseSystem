using DomainLayer.Models.Parties;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SupplierController : GenericController<Supplier, CreateSupplierDto, ViewSupplierDto, string>
	{
		public SupplierController(IGenericService<Supplier, CreateSupplierDto, ViewSupplierDto, string> _service) : base(_service)
		{
		}
	}
}