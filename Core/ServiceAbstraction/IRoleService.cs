using Microsoft.AspNetCore.Identity;

namespace ServiceAbstraction
{
	public interface IRoleService
	{
		Task<IEnumerable<string?>?> GetAllRoles();
		Task<IdentityResult> CreateRole(string roleName);
		Task<IdentityResult> DeleteRole(string roleName);
		Task<IdentityResult> AssignRoleToUser(string userName, string roleName);
		Task<IdentityResult> RemoveRoleFromUserAsync(string userName, string roleName);
		Task<IEnumerable<string>> GetUsersInRoleAsync(string roleName);
	}
}
