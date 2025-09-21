using DomainLayer.Models.Parties;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InvoiceController : GenericController<Invoice, CreateInvoiceDto, ViewInvoiceDto, string>
	{
		public InvoiceController(IGenericService<Invoice, CreateInvoiceDto, ViewInvoiceDto, string> _service) : base(_service)
		{
		}
	}
}