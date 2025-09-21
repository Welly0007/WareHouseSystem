namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class ViewDefectiveDto
	{
		public string Id { get; set; } = string.Empty;
		public string ProductId { get; set; } = string.Empty;
		public string ProductName { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		public string WarehouseId { get; set; } = string.Empty;
		public string WarehouseName { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public string Reason { get; set; } = string.Empty;
		public DateTime ReportedAt { get; set; }
		public string ReportedById { get; set; } = string.Empty;
		public string ReportedByName { get; set; } = string.Empty;
	}
}