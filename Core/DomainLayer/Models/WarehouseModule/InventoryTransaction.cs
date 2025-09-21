using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models.UserModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos;

namespace DomainLayer.Models.WarehouseModule
{
	public class InventoryTransaction : BaseEntity
	{
		public DateTime Date { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public TransactionTypes Type { get; set; }
		public int Quantity { get; set; }
		// Foreign Keys
		public string ProductId { get; set; } = null!;
		public string CreatedById { get; set; } = null!;
		public string WarehouseId { get; set; } = null!;
		// Navigation Properties
		public virtual Product Product { get; set; } = null!;
		public virtual User CreatedBy { get; set; } = null!;
		public virtual Warehouse Warehouse { get; set; } = null!;
	}
}
