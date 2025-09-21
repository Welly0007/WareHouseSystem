using DomainLayer.Models.UserModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> b)
		{
			//b.Ignore(u => u.PhoneNumberConfirmed);
			//b.Ignore(u => u.TwoFactorEnabled);
			//b.Ignore(u => u.LockoutEnd);
			//b.Ignore(u => u.LockoutEnabled);
			//b.Ignore(u => u.AccessFailedCount);
			//b.Ignore(u => u.NormalizedUserName);
			//b.Ignore(u => u.NormalizedEmail);
			//b.Ignore(u => u.EmailConfirmed);
			//b.Ignore(u => u.SecurityStamp);
			//b.Ignore(u => u.ConcurrencyStamp);
		}
	}
}
