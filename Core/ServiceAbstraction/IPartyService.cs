using Shared;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace ServiceAbstraction
{
	public interface IPartyService
	{
		Task<PaginatedResult<ViewPaymentDto>> GetSupplierPayments(string supplierId);
		Task<PaginatedResult<ViewReceiptDto>> GetCustomerReceipts(string customerId);
	}
}
