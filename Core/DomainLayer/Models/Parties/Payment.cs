using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Parties
{
	public class Payment : BasePartyEntity
	{
		[Column(TypeName = "decimal(18,2)")]
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		[Column(TypeName = "NVARCHAR(MAX)")]
		public string Notes { get; set; } = string.Empty;
		public string SupplierId { get; set; } = null!;
		public virtual Supplier Supplier { get; set; } = null!;
	}
}
