namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos
{
	public class ProductsTransferResults
	{
		public int SuccessfulTransfers { get; set; }
		public int FailedTransfers { get; set; }
		public List<string> Messages { get; set; } = [];
		public int TotalMessages => Messages.Count;
	}
}
