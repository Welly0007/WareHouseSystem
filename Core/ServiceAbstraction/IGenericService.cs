namespace ServiceAbstraction
{
	public interface IGenericService<TEntity, TIn, TOut, TKEy>
	{
		Task<IEnumerable<TOut>> GetAllAsync();
		Task<TOut> GetByIdAsync(TKEy id);
		Task<int> CreateAsync(TIn entity);
		Task<int> UpdateAsync(TKEy id, TIn entity);
		Task<int> DeleteAsync(TKEy id);

	}
}
