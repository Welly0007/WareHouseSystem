namespace DomainLayer.Models.UserModule
{
	public class Notification : BaseEntity
	{
		public string Title { get; set; } = null!;
		public string Message { get; set; } = null!;
		public DateTime DateCreated { get; set; }
		public bool IsRead { get; set; }
		public virtual User User { get; set; } = null!;
	}
}
