namespace DomainLayer.Models.WarehouseModule
{
	public class Payroll : BaseEntity
	{
		public virtual Employee Employee { get; set; } = null!;
		public string EmployeeId { get; set; } = null!;
		public int Month { get; set; }
		public int Year { get; set; }
		public decimal BaseSalary { get; set; }
		public decimal Allowances { get; set; }
		public decimal Deductions { get; set; }
		public decimal Overtime { get; set; }
		public decimal NetSalary => BaseSalary + Allowances + Overtime - Deductions;
	}
}
