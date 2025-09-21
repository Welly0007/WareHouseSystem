namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class CreateProductUnitDto
	{
		public string Type { get; set; } = null!;
		public int QuantityOf { get; set; }
		public int? ProductUnitId { get; set; }
	}
}