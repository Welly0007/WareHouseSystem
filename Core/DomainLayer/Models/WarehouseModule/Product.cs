using DomainLayer.Models.WarehouseModule;
using Shared;

namespace DomainLayer.Models
{
	public class Product : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string Code { get; set; } = null!;
		public string BatchNumber { get; set; } = null!;
		// Quantity fields
		public int LowStockThreshold { get; set; }
		public int Quantity { get; set; }
		public decimal BuyingPrice { get; set; }
		public decimal SellingPrice { get; set; }
		//Expiry fields
		public DateTime? ExpiryDate { get; set; }
		public int? NearExpireThreshold { get; set; }
		public TimeDurationEnum? DurationType { get; set; }
		public bool Expirable { get; set; } = true;
		// Foreign Keys
		public string CategoryId { get; set; } = null!;
		public virtual Category Category { get; set; } = null!;
		public string WarehouseId { get; set; } = null!;
		public virtual Warehouse Warehouse { get; set; } = null!;
		public string? ProductUnitId { get; set; }
		public virtual ProductUnit? Unit { get; set; }

		// Fix for CS1061: Ensure ExpiryDate and NearExpireThreshold are not null before calling Add* methods
		public DateTime GetNearExpiryDate()
		{
			if (ExpiryDate == null || NearExpireThreshold == null || DurationType == null)
				throw new InvalidOperationException("ExpiryDate, NearExpireThreshold, and DurationType must not be null.");

			return DurationType switch
			{
				TimeDurationEnum.Days => ExpiryDate.Value.AddDays(-NearExpireThreshold.Value),
				TimeDurationEnum.Months => ExpiryDate.Value.AddMonths(-NearExpireThreshold.Value),
				TimeDurationEnum.Years => ExpiryDate.Value.AddYears(-NearExpireThreshold.Value),
				_ => ExpiryDate.Value
			};
		}

		public bool IsNearExpiry()
		{
			if (!Expirable || ExpiryDate == null || NearExpireThreshold == null || DurationType == null) return false;

			var now = DateTime.UtcNow;
			var nearExpiryDate = GetNearExpiryDate();
			return now >= nearExpiryDate && now < ExpiryDate.Value;
		}

		public bool IsExpired()
		{
			return Expirable && ExpiryDate != null && DateTime.UtcNow >= ExpiryDate.Value;
		}
	}
}
