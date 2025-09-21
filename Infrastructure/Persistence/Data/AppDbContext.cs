using DomainLayer.Models;
using DomainLayer.Models.Parties;
using DomainLayer.Models.UserModule;
using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
			modelBuilder.Entity<RefreshToken>()
				.HasOne(rt => rt.User)
				.WithOne(u => u.RefreshToken)
				.HasForeignKey<RefreshToken>(rt => rt.UserId)
				.OnDelete(DeleteBehavior.Cascade);
			// Ignore Identity tables that are not needed
			//modelBuilder.Ignore<IdentityUserLogin<string>>();
			//modelBuilder.Ignore<IdentityUserToken<string>>();
			//modelBuilder.Ignore<IdentityUserClaim<string>>();
			//modelBuilder.Ignore<IdentityRoleClaim<string>>();
			// Apply global configurations
			//	foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			//	{
			//		foreach (var property in entityType.GetProperties())
			//		{
			//			if (property.Name == "Name")
			//			{
			//				property.IsNullable = false;
			//				property.SetColumnType("nvarchar(200)");
			//			}
			//			if (property.Name == "Description")
			//			{
			//				property.IsNullable = true;
			//				property.SetColumnType("nvarchar(MAX)");
			//			}
			//			if (property.Name == "Phone")
			//			{
			//				property.IsNullable = false;
			//				property.SetColumnType("NVARCHAR(50)");
			//			}
			//			if (property.Name == "Email")
			//			{
			//				property.IsNullable = false;
			//				property.SetColumnType("NVARCHAR(200)");
			//			}
			//			if (property.Name == "Location")
			//			{
			//				property.IsNullable = false;
			//				property.SetColumnType("NVARCHAR(300)");
			//			}

			//		}
			//	}
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }
		public DbSet<ProductUnit> Units { get; set; }
		public DbSet<Receipt> Receipts { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
		public DbSet<Payroll> Payrolls { get; set; }
		public DbSet<DefectiveReport> defectiveReports { get; set; }
		// Use 'new' to hide the inherited Roles property with your custom Role type
		public new DbSet<Role> Roles { get; set; }
	}
}
