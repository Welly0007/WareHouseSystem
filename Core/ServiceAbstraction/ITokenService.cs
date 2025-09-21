using DomainLayer.Models.UserModule;
using Shared.DataTransferObjects.UserModuleDto;

namespace ServiceAbstraction
{
	public interface ITokenService
	{
		public Task<TokenDto> CreateToken(User user);
		public string CreateAccessToken(User user);
		public Task<string?> ValidateRefreshTokenAsync(string userName, string refreshToken);
	}
}
