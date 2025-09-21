namespace Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos
{
	public class CreateProductDto
	{
		public string Name { get; set; } = null!;
		public string Code { get; set; } = null!;
		public int Quantity { get; set; }
		public int LowStockThreshold { get; set; }
		public decimal BuyingPrice { get; set; }
		public decimal SellingPrice { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public int? NearExpireThreshold { get; set; }
		public TimeDurationEnum? DurationType { get; set; }
		public bool Expirable { get; set; } = true;
		public string BatchNumber { get; set; } = null!;
		public string CategoryId { get; set; } = null!;
		public string WarehouseId { get; set; } = null!;
		public string? ProductUnitId { get; set; }
	}
}
