using DomainLayer.Models.Parties;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : GenericController<Customer, CreateCustomerDto, ViewCustomerDto, string>
	{
		public CustomerController(IGenericService<Customer, CreateCustomerDto, ViewCustomerDto, string> _service) : base(_service)
		{
		}
	}
}