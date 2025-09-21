using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	public class GenericController<TEntity, TIn, TOut, TKey>(IGenericService<TEntity, TIn, TOut, TKey> _service) : ControllerBase where TEntity : BaseEntity
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TOut>>> GetAll()
		{
			var entities = await _service.GetAllAsync();
			return Ok(entities);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TOut>> GetById([FromRoute] TKey id)
		{
			var entity = await _service.GetByIdAsync(id!);
			return Ok(entity);
		}

		[HttpPost]
		public async Task<ActionResult<int>> Create([FromBody] TIn input)
		{
			var result = await _service.CreateAsync(input);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<int>> Update([FromRoute] TKey id, [FromBody] TIn input)
		{
			var result = await _service.UpdateAsync(id, input);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<int>> Delete(TKey id)
		{
			var result = await _service.DeleteAsync(id);
			return Ok(result);
		}
	}
}
