using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DomainLayer.Models.UserModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DataTransferObjects.UserModuleDto;

namespace Service
{
	public class TokenService(IConfiguration configuration, UserManager<User> _userManager) : ITokenService
	{
		public string CreateAccessToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.NameIdentifier, user.Id),
			};

			// Add role claims
			var roles = _userManager.GetRolesAsync(user).Result;
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var appsettings = configuration.GetSection("AppSettings");
			var key = new SymmetricSecurityKey(
				Encoding.UTF8
				.GetBytes(appsettings["SecretKey"]!)
				);
			var creds = new SigningCredentials(
				key,
				SecurityAlgorithms.HmacSha512Signature
				);
			var tokenDescriptor = new JwtSecurityToken(
				issuer: appsettings["Issuer"]!,
				audience: appsettings["Audience"]!,
				expires: DateTime.Now.AddMinutes(double.Parse(appsettings["ExpiryInMinutes"]!)),
				claims: claims,
				signingCredentials: creds
				);
			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}
		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
		private async Task<string> SetAndSaveRefreshTokenAsync(User user)
		{
			var refreshToken = GenerateRefreshToken();
			if (user.RefreshToken != null)
			{
				user.RefreshToken.Value = refreshToken;
				user.RefreshToken.Expires = DateTime.UtcNow.AddDays(7);
				user.RefreshToken.Created = DateTime.UtcNow;
				user.RefreshToken.Revoked = null; // Reset revoked status
			}
			else
			{
				user.RefreshToken = new RefreshToken()
				{
					Value = refreshToken,
					Expires = DateTime.UtcNow.AddDays(7),
					Created = DateTime.UtcNow,
				};
			}

			await _userManager.UpdateAsync(user);
			return refreshToken;
		}
		public async Task<string?> ValidateRefreshTokenAsync(string userName, string refreshToken)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user is null || user.RefreshToken.Value != refreshToken
				|| user.RefreshToken.Expires <= DateTime.UtcNow)
			{
				return null;
			}

			return CreateAccessToken(user);
		}

		public async Task<TokenDto> CreateToken(User user)
		{
			var response = new TokenDto
			{
				AccessToken = CreateAccessToken(user),
				RefreshToken = await SetAndSaveRefreshTokenAsync(user),
			};
			return response;
		}
	}
}
