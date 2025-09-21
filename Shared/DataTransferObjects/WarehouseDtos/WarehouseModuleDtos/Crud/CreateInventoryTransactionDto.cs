namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class CreateInventoryTransactionDto
	{
		public DateTime Date { get; set; }
		public TransactionTypes Type { get; set; }
		public int Quantity { get; set; }
		// Foreign Keys
		public string ProductId { get; set; } = null!;
		public string CreatedById { get; set; } = null!;
		public string WarehouseId { get; set; } = null!;
	}
}