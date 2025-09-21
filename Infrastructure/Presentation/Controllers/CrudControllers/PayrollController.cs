using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PayrollController : GenericController<Payroll, CreatePayrollDto, ViewPayrollDto, string>
	{
		public PayrollController(IGenericService<Payroll, CreatePayrollDto, ViewPayrollDto, string> _service) : base(_service)
		{
		}
	}
}