namespace Shared.DataTransferObjects.WarehouseDtos.PartiesDtos
{
	public class ViewInvoiceDto
	{
		public string Id { get; set; } = null!;
		public DateTime Date { get; set; }
		public string Type { get; set; } = string.Empty;
		public decimal TotalAmount { get; set; }
		public string CustomerId { get; set; } = null!;
		public string SupplierId { get; set; } = null!;
		public string CreatedById { get; set; } = null!;
		public string? CustomerName { get; set; }
		public string? SupplierName { get; set; }
		public string? CreatedByName { get; set; }
	}
}