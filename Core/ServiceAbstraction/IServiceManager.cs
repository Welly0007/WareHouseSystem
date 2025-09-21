namespace ServiceAbstraction
{
	public interface IServiceManager
	{
		//public IGenericService<TEntity, TIn, TOut> GenericService { get; }
		public IProductService ProductService { get; }
		public IAuthService AuthService { get; }
		public IRoleService RoleService { get; }
		public IPartyService partyService { get; }
	}
}
