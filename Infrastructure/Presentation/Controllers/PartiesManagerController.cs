using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PartiesManagerController(IServiceManager _serviceManager) : ControllerBase
	{
		[HttpGet("getSupplierPayments")]
		public async Task<ActionResult<PaginatedResult<ViewPaymentDto>>> GetSupplierPayments([FromQuery] string supplierId)
		{
			var payments = await _serviceManager.partyService.GetSupplierPayments(supplierId);
			return Ok(payments);

		}
		[HttpGet("getCustomerReceipts")]
		public async Task<ActionResult<PaginatedResult<ViewReceiptDto>>> GetCustomerReciepts([FromQuery] string customerId)
		{
			var receipts = await _serviceManager.partyService.GetCustomerReceipts(customerId);
			return Ok(receipts);
		}

	}
}
