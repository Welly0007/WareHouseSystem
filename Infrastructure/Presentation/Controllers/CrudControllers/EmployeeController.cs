using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : GenericController<Employee, CreateEmployeeDto, ViewEmployeeDto, string>
	{
		public EmployeeController(IGenericService<Employee, CreateEmployeeDto, ViewEmployeeDto, string> _service) : base(_service)
		{
		}
	}
}