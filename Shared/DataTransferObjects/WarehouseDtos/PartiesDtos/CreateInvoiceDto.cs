namespace Shared.DataTransferObjects.WarehouseDtos.PartiesDtos
{
	public class CreateInvoiceDto
	{
		public DateTime Date { get; set; }
		public string Type { get; set; } = string.Empty;
		public decimal TotalAmount { get; set; }
		public string CustomerId { get; set; } = null!;
		public string SupplierId { get; set; } = null!;
		public string CreatedById { get; set; } = null!;
	}
}