namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class CreateWarehouseDto
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string Location { get; set; } = null!;
	}
}