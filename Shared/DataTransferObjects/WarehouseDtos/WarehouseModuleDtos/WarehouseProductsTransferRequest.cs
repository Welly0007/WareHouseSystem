namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos
{
	public class WarehouseProductsTransferRequest
	{
		public string SourceWarehouseId { get; set; } = null!;
		public string DestinationWarehouseId { get; set; } = null!;
		public List<Dictionary<string, int>> Products { get; set; } = [];
	}
}
