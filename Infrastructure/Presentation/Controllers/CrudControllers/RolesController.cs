using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.UserModuleDto;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	//[Authorize(Roles = "Admin")]
	public class RolesController(IServiceManager _serviceManager) : ControllerBase
	{
		// Implement role-related actions here (e.g., create, delete, assign roles)
		[HttpGet("GetAllRoles")]
		public async Task<ActionResult<IEnumerable<string>>> GetAllRoles()
		{
			var roles = await _serviceManager.RoleService.GetAllRoles();
			return Ok(roles);
		}
		[HttpPost("CreateRole")]
		public async Task<ActionResult> CreateRole([FromBody] string roleName)
		{
			await _serviceManager.RoleService.CreateRole(roleName);
			return Ok($"Role '{roleName}' created successfully.");
		}
		[HttpDelete("DeleteRole")]
		public async Task<ActionResult> DeleteRole([FromBody] string roleName)
		{
			var result = await _serviceManager.RoleService.DeleteRole(roleName);
			return Ok($"Role '{result}' deleted successfully.");
		}
		[HttpPost("AssignRoleToUser")]
		public async Task<ActionResult> AssignRoleToUser([FromBody] RoleRequest request)
		{
			await _serviceManager.RoleService.AssignRoleToUser(request.UserName, request.RoleName);
			return Ok($"Role '{request.RoleName}' assigned to user '{request.UserName}' successfully.");
		}
		[HttpPost("remove")]
		public async Task<IActionResult> RemoveRoleFromUser([FromBody] RoleRequest request)
		{
			var result = await _serviceManager.RoleService.RemoveRoleFromUserAsync(request.UserName, request.RoleName);
			if (result.Succeeded)
			{
				return Ok(new { message = $"Role '{request.RoleName}' removed from user '{request.UserName}'." });
			}
			return BadRequest(result.Errors);
		}

		[HttpGet("{roleName}/users")]
		public async Task<IActionResult> GetUsersInRole(string roleName)
		{
			var users = await _serviceManager.RoleService.GetUsersInRoleAsync(roleName);
			return Ok(users);
		}
	}
}
