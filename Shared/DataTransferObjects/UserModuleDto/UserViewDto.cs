namespace Shared.DataTransferObjects.UserModuleDto
{
	public class UserViewDto
	{
		public string Id { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string[] Roles { get; set; } = [];
	}
}
