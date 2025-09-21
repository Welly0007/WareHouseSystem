namespace Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos
{
	public class ViewProductDto
	{
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = null!;
		public decimal BuyingPrice { get; set; }
		public decimal SellingPrice { get; set; }
		public int Quantity { get; set; }
		public string CategoryName { get; set; } = null!;
		public string WarehouseName { get; set; } = null!;
		public string Code { get; set; } = null!;
		public string BatchNumber { get; set; } = null!;
		public DateTime ExpiryDate { get; set; }
		public int NearExpireThreshold { get; set; }
		public TimeDurationEnum DurationType { get; set; }
		public bool Expirable { get; set; }
		public int LowStockThreshold { get; set; }
		
		// Computed properties for UI
		public bool IsNearExpiry { get; set; }
		public bool IsExpired { get; set; }
		public DateTime? NearExpiryDate { get; set; }
	}
}
