using Shared.DataTransferObjects.UserModuleDto;

namespace ServiceAbstraction
{
	public interface IAuthService
	{
		Task<UserViewDto?> Register(RegisterRequest RegisterRequest);
		Task<TokenDto?> Login(LoginRequest loginRequest);
		Task<string?> RefreshTokenAsync(string userName, string refreshToken);
	}
}
