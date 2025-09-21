using AutoMapper;
using DomainLayer.Exceptions;
using DomainLayer.Models.UserModule;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared.DataTransferObjects.UserModuleDto;

namespace Service
{
	public class AuthService(IMapper _mapper, ITokenService tokenService, UserManager<User> _userManager) : IAuthService
	{
		public async Task<UserViewDto?> Register(RegisterRequest Request)
		{
			if (await _userManager.FindByNameAsync(Request.Username) is not null)
			{
				throw new UserAlreadyExist($"user with username: {Request.Username} already exists");
			}
			var user = _mapper.Map<User>(Request);

			user.PasswordHash = new PasswordHasher<User>().HashPassword(user, Request.Password!);
			var createdUser = await _userManager.CreateAsync(user);
			if (createdUser is null)
			{
				throw new Exception("Can Not Create User Now, Try Again Later");
			}
			return _mapper.Map<UserViewDto>(user);
		}

		public async Task<TokenDto?> Login(LoginRequest loginDto)
		{
			var user = await _userManager.FindByNameAsync(loginDto.Username);
			if (user is not null && new PasswordHasher<User>()
				.VerifyHashedPassword(
				user,
				user.PasswordHash!,
				loginDto.Password
				)
				== PasswordVerificationResult.Success)
			{
				return await tokenService.CreateToken(user);

			}
			else
			{
				throw new InvalidUserCreds("Invalid Username or Password");
			}

		}
		public async Task<string?> RefreshTokenAsync(string userName, string refreshToken)
		{
			return await tokenService.ValidateRefreshTokenAsync(userName, refreshToken);
		}
	}
}
