namespace Shared.DataTransferObjects.WarehouseDtos.UserModuleDtos
{
	public class CreateNotificationDto
	{
		public string Title { get; set; } = null!;
		public string Message { get; set; } = null!;
		public DateTime DateCreated { get; set; }
		public bool IsRead { get; set; }
		public string? UserId { get; set; }
	}
}