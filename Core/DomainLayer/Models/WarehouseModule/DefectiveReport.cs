using DomainLayer.Models.UserModule;

namespace DomainLayer.Models.WarehouseModule
{
	public class DefectiveReport : BaseEntity
	{
		public string ProductId { get; set; } = string.Empty;
		public virtual Product Product { get; set; } = null!;
		public virtual Warehouse wareHouse { get; set; } = null!;
		public string WarehouseId { get; set; } = null!;
		public int Quantity { get; set; }
		public string Reason { get; set; } = string.Empty;
		public DateTime ReportedAt { get; set; }
		public virtual User ReportedBy { get; set; } = null!;
		public string ReportedById { get; set; } = string.Empty;

	}
}
