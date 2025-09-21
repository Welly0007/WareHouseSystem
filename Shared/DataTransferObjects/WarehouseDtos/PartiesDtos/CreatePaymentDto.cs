namespace Shared.DataTransferObjects.WarehouseDtos.PartiesDtos
{
	public class CreatePaymentDto
	{
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Notes { get; set; } = string.Empty;
		public string SupplierId { get; set; } = null!;
	}
}