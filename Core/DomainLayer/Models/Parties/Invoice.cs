using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models.UserModule;

namespace DomainLayer.Models.Parties
{
	public class Invoice : BasePartyEntity
	{
		public DateTime Date { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string Type { get; set; } = string.Empty;
		[Column(TypeName = "DECIMAL(18,2)")]
		public decimal TotalAmount { get; set; }
		// Foreign Keys
		public string CustomerId { get; set; } = null!;
		public string SupplierId { get; set; } = null!;
		public string CreatedById { get; set; } = null!;
		// Navigation Properties
		public virtual Customer Customer { get; set; } = null!;
		public virtual Supplier Supplier { get; set; } = null!;
		public virtual User CreatedBy { get; set; } = null!;
	}
}
