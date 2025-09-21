using DomainLayer.Models.Parties;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReceiptController : GenericController<Receipt, CreateReceiptDto, ViewReceiptDto, string>
	{
		public ReceiptController(IGenericService<Receipt, CreateReceiptDto, ViewReceiptDto, string> _service) : base(_service)
		{
		}
	}
}