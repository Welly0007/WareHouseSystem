using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Models.UserModule
{
	public class User : IdentityUser
	{
		public string Name { get; set; } = null!;
		public bool IsActive { get; set; } = true;
		public virtual ICollection<Role>? UserRoles { get; set; }

		public virtual RefreshToken? RefreshToken { get; set; }

	}
}
