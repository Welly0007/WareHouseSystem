namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class ViewInventoryTransactionDto
	{
		public string Id { get; set; } = null!;
		public DateTime Date { get; set; }
		public string Type { get; set; } = string.Empty;
		public int Quantity { get; set; }
		// Foreign Keys
		public string ProductId { get; set; } = null!;
		public string CreatedById { get; set; } = null!;
		public string WarehouseId { get; set; } = null!;
		public string ProductName { get; set; } = string.Empty;
		public string CreatedByName { get; set; } = string.Empty;
		public string WarehouseName { get; set; } = string.Empty;
	}
}