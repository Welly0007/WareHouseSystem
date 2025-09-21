using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;

namespace Service
{
	public class ServiceManager(IServiceProvider serviceProvider) : IServiceManager
	{
		public IProductService ProductService => _productService.Value;
		public IAuthService AuthService => _authService.Value;
		public IRoleService RoleService => _roleService.Value;
		public IPartyService partyService => _partyService.Value;
		private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => serviceProvider.GetRequiredService<IProductService>());

		private readonly Lazy<IAuthService> _authService = new Lazy<IAuthService>(() => serviceProvider.GetRequiredService<IAuthService>());
		private readonly Lazy<IRoleService> _roleService = new Lazy<IRoleService>(() => serviceProvider.GetRequiredService<IRoleService>());
		private readonly Lazy<IPartyService> _partyService = new Lazy<IPartyService>(() => serviceProvider.GetRequiredService<IPartyService>());
	}
}
