using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Parties
{
	public class Receipt : BasePartyEntity
	{
		[Column(TypeName = "decimal(18,2)")]
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		[Column(TypeName = "NVARCHAR(MAX)")]
		public string Notes { get; set; } = string.Empty;
		public string CustomerId { get; set; } = null!;
		public virtual Customer Customer { get; set; } = null!;
	}
}
