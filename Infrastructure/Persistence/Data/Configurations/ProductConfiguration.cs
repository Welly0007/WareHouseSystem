using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			#region Relations Define
			builder.HasOne(p => p.Category)
		.WithMany()
		.HasForeignKey(p => p.CategoryId);
			builder.HasOne(p => p.Warehouse)
				.WithMany()
				.HasForeignKey(p => p.WarehouseId);

			// Configure decimal properties
			builder.Property(p => p.BuyingPrice)
				.HasColumnType("decimal(10,2)");
			builder.Property(p => p.SellingPrice)
				.HasColumnType("decimal(10,2)");
			#endregion

			#region Specific Configuration
			builder.Property(p => p.Code)
				.IsRequired()
				.HasColumnType("NVARCHAR(100)");
			builder.Property(p => p.BatchNumber)
				.IsRequired()
				.HasColumnType("NVARCHAR(100)");
			builder.Property(p => p.Name)
				.IsRequired()
				.HasColumnType("nvarchar(200)");
			#endregion
		}
	}
}
