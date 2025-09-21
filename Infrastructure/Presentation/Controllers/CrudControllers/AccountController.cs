using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.UserModuleDto;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController(IServiceManager _serviceManager) : ControllerBase
	{
		// Implement account-related actions here (e.g., login, register, logout)
		[HttpPost("Register")]
		public async Task<ActionResult<UserViewDto>> Register([FromBody] RegisterRequest request)
		{

			var user = await _serviceManager.AuthService.Register(request);
			return Ok(user);
		}
		[HttpPost("Login")]
		public async Task<ActionResult<TokenDto>> Login([FromBody] LoginRequest request)
		{
			// Implement login logic here
			var token = await _serviceManager.AuthService.Login(request);
			return Ok(token);
		}
		[HttpPost("RefreshToken")]
		public async Task<ActionResult<string>> RefreshToken([FromForm] string userName, [FromForm] string refreshToken)
		{
			var newAccessToken = await _serviceManager.AuthService.RefreshTokenAsync(userName, refreshToken);
			if (newAccessToken is null)
			{
				return Unauthorized("Invalid Request");
			}
			return Ok(newAccessToken);
		}

		[HttpGet("TestAdmin")]
		[Authorize(Roles = "Admin")]
		public IActionResult TestAdmin()
		{
			return Ok("Admin Access - You have successfully accessed an Admin-only endpoint!");
		}

		[HttpGet("TestAuth")]
		[Authorize]
		public IActionResult TestAuth()
		{
			var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var userName = User.FindFirst(ClaimTypes.Name)?.Value;
			var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

			return Ok(new
			{
				UserId = userId,
				UserName = userName,
				Roles = roles,
				AllClaims = claims,
				User.Identity?.IsAuthenticated,
				User.Identity?.AuthenticationType,
				Message = "Authentication test successful!"
			});
		}

		[HttpGet("Public")]
		public IActionResult PublicEndpoint()
		{
			return Ok(new
			{
				message = "This is a public endpoint that doesn't require authentication",
				timestamp = DateTime.UtcNow
			});
		}

		[HttpGet("TestUnauthorized")]
		[Authorize]
		public IActionResult TestUnauthorized()
		{
			return Ok("If you see this, you are authenticated!");
		}
	}
}
