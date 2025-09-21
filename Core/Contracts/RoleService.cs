using DomainLayer.Models.UserModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceAbstraction;

namespace Service
{
	public class RoleService(RoleManager<Role> _roleManager, UserManager<User> _userManager) : IRoleService
	{
		public async Task<IdentityResult> AssignRoleToUser(string userName, string roleName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			var roleExists = await _roleManager.RoleExistsAsync(roleName);
			if (user is null || !roleExists)
			{
				return IdentityResult.Failed(new IdentityError
				{
					Code = "UserOrRoleNotFound",
					Description = "User or Role doesn't Exist"
				});
			}
			return await _userManager.AddToRoleAsync(user, roleName);

		}

		public async Task<IdentityResult> CreateRole(string roleName)
		{
			if (string.IsNullOrWhiteSpace(roleName))
			{
				return IdentityResult.Failed(new IdentityError
				{
					Code = "InvalidRoleName",
					Description = "Role name cannot be null or empty."
				});
			}
			var role = new Role { Name = roleName };
			return await _roleManager.CreateAsync(role);
		}

		public async Task<IdentityResult> DeleteRole(string roleName)
		{
			if (roleName == "Admin" || roleName == "User")
			{
				return IdentityResult.Failed(new IdentityError
				{
					Code = "CannotDeleteDefaultRole",
					Description = "Cannot delete default roles like Admin or User."
				});
			}
			var role = await _roleManager.FindByNameAsync(roleName);
			if (role is null)
			{
				return IdentityResult.Failed(new IdentityError
				{
					Code = "RoleNotFound",
					Description = "Role does not exist."
				});
			}
			return await _roleManager.DeleteAsync(role);
		}

		public async Task<IEnumerable<string?>?> GetAllRoles()
		{
			var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
			return roles;
		}

		public async Task<IEnumerable<string>> GetUsersInRoleAsync(string roleName)
		{
			var users = await _userManager.GetUsersInRoleAsync(roleName);
			return users.Select(u => u.UserName!).ToList();
		}

		public async Task<IdentityResult> RemoveRoleFromUserAsync(string userName, string roleName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user is null)
			{
				return IdentityResult.Failed(new IdentityError
				{
					Code = "UserNotFound",
					Description = "User doesn't Exist"
				});
			}
			return await _userManager.RemoveFromRoleAsync(user, roleName);
		}
	}
}
