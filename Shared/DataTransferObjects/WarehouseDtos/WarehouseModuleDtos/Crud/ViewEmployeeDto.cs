namespace Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud
{
	public class ViewEmployeeDto
	{
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string JobTitle { get; set; } = string.Empty;
		public DateTime HireDate { get; set; }
		public decimal Salary { get; set; }
	}
}