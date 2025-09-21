namespace Shared.DataTransferObjects.WarehouseDtos.PartiesDtos
{
	public class ViewPaymentDto
	{
		public string Id { get; set; } = null!;
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Notes { get; set; } = string.Empty;
		public string SupplierId { get; set; } = null!;
		public string? SupplierName { get; set; }
	}
}