using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models;
using ServiceAbstraction;

namespace Service
{
	public class GenericService<TEntity, TIn, TOut, TKey>(IUnitOfWork _unitOfWork, IMapper mapper) : IGenericService<TEntity, TIn, TOut, TKey> where TEntity : BaseEntity
	{
		public virtual async Task<int> CreateAsync(TIn input)
		{
			if (input is null)
			{
				throw new ArgumentNullException(nameof(input), "Input entity cannot be null.");
			}
			var entity = mapper.Map<TIn, TEntity>(input);
			await _unitOfWork.GetRepository<TEntity>().AddAsync(entity);
			return await _unitOfWork.CompleteAsync();
		}

		public async Task<int> DeleteAsync(TKey id)
		{
			if (id is null)
			{
				throw new ArgumentNullException(nameof(id), "ID cannot be null.");
			}
			var repo = _unitOfWork.GetRepository<TEntity>();
			var EntityToBeDeleted = await repo.GetByIdAsync(id);
			if (EntityToBeDeleted == null)
			{
				throw new NotFoundException($"Entity with id {id} not found.");
			}
			_unitOfWork.GetRepository<TEntity>().Delete(EntityToBeDeleted);
			var result = await _unitOfWork.CompleteAsync();
			return result;
		}

		public async Task<IEnumerable<TOut>> GetAllAsync()
		{
			var repo = _unitOfWork.GetRepository<TEntity>();
			var entities = await repo.GetAllAsync();
			return mapper.Map<IEnumerable<TEntity>, IEnumerable<TOut>>(entities);
		}

		public async Task<TOut> GetByIdAsync(TKey id)
		{
			if (id is null)
			{
				throw new ArgumentNullException(nameof(id), "ID cannot be null.");
			}
			var repo = _unitOfWork.GetRepository<TEntity>();
			var entity = await repo.GetByIdAsync(id);
			if (entity == null)
			{
				throw new NotFoundException($"Entity with id {id} not found.");
			}
			return mapper.Map<TEntity, TOut>(entity);
		}

		public async Task<int> UpdateAsync(TKey id, TIn input)
		{
			if (input is null || id is null)
			{
				throw new ArgumentNullException(nameof(input), "Input entity and Id cannot be null.");
			}
			var repo = _unitOfWork.GetRepository<TEntity>();
			var existingEntity = await repo.GetByIdAsync(id);
			if (existingEntity == null)
			{
				throw new NotFoundException($"Entity with id {id} not found.");
			}
			mapper.Map(input, existingEntity);
			_unitOfWork.GetRepository<TEntity>().Update(existingEntity);
			return await _unitOfWork.CompleteAsync();
		}
	}
}
