using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects.WarehouseDtos.ProductModuleDtos;
using Shared.ProductSpecifications;

namespace Presentation.Controllers.CrudControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController(IServiceManager serviceManager) : ControllerBase
	{
		//Get ALL
		[HttpGet]
		public async Task<ActionResult<PaginatedResult<ViewProductDto>>> GetAllProducts([FromQuery] ProductQueryParams QueryParams)
		{
			var productsPaginated = await serviceManager.ProductService.GetAllProducts(QueryParams);
			return Ok(productsPaginated);
		}
		//GetById
		[HttpGet("{id}")]
		public async Task<ActionResult<ViewProductDto>> GetProductById(string id)
		{
			var product = await serviceManager.ProductService.GetProductById(id);
			return Ok(product);
		}
		//Create
		[HttpPost]
		public async Task<ActionResult<ViewProductDto>> CreateProductAsync([FromBody] CreateProductDto request)
		{
			if (request is null)
				return BadRequest("Request object is null");
			var createdProduct = await serviceManager.ProductService.CreateProductAsync(request);
			return Ok(createdProduct);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteProductAsync(string id)
		{
			var result = await serviceManager.ProductService.DeleteProductAsync(id);
			return Ok(result);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<ViewProductDto>> UpdateProductAsync(string id, [FromBody] CreateProductDto request)
		{
			if (request is null || string.IsNullOrWhiteSpace(id))
				return BadRequest("Invalid request data.");
			var updatedProduct = await serviceManager.ProductService.UpdateProductAsync(id, request);
			return Ok(updatedProduct);
		}


	}
}
