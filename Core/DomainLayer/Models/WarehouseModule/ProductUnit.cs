namespace DomainLayer.Models.WarehouseModule
{
	public class ProductUnit : BaseEntity
	{
		public string Type { get; set; } = null!;
		public int QuantityOf { get; set; }
		public int? ProductUnitId { get; set; }
		public virtual ProductUnit? Unit { get; set; }
	}
}
