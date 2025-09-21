namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class CreateDefectiveDto
	{
		public string ProductId { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public string Reason { get; set; } = string.Empty;
		public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
		public string ReportedById { get; set; } = string.Empty;
	}
}