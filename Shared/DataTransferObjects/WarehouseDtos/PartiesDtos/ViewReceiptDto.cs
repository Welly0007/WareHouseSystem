namespace Shared.DataTransferObjects.WarehouseDtos.PartiesDtos
{
	public class ViewReceiptDto
	{
		public string Id { get; set; } = null!;
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Notes { get; set; } = string.Empty;
		public string CustomerId { get; set; } = null!;
		public string? CustomerName { get; set; }
	}
}