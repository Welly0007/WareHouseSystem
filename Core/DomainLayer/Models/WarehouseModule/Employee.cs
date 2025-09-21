using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.WarehouseModule
{
	public class Employee : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		[Column(TypeName = "varchar(100)")]
		public string JobTitle { get; set; } = string.Empty;
		public DateTime HireDate { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Salary { get; set; }

	}
}
