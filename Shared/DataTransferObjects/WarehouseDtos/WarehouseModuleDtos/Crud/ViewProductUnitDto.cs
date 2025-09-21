namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class ViewProductUnitDto
	{
		public string Id { get; set; } = null!;
		public string Type { get; set; } = null!;
		public int QuantityOf { get; set; }
		public int? ProductUnitId { get; set; }
	}
}