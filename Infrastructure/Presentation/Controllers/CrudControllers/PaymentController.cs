using DomainLayer.Models.Parties;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PaymentController : GenericController<Payment, CreatePaymentDto, ViewPaymentDto, string>
	{
		public PaymentController(IGenericService<Payment, CreatePaymentDto, ViewPaymentDto, string> _service) : base(_service)
		{
		}
	}
}