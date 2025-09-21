using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
	public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
	{
		public void Configure(EntityTypeBuilder<Warehouse> builder)
		{
			builder.Property(w => w.Location)
				.IsRequired()
				.HasColumnType("NVARCHAR(300)");
		}
	}
}
