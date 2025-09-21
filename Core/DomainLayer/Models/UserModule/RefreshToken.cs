using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.UserModule
{
	public class RefreshToken
	{
		public int Id { get; set; }
		public string Value { get; set; } = string.Empty;
		public DateTime Expires { get; set; }
		public bool IsExpired => DateTime.UtcNow >= Expires;
		public DateTime Created { get; set; }
		public DateTime? Revoked { get; set; }
		public bool IsActive => Revoked == null && !IsExpired;
		// Foreign key to User (RefreshToken depends on User)
		[ForeignKey(nameof(User))]
		public string UserId { get; set; } = null!;

		// Navigation property to User
		public virtual User User { get; set; } = null!;
	}
}
