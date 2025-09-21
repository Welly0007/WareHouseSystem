using DomainLayer.Exceptions;
using Shared;

namespace Warehouse.Web.CustomMiddleWares
{
	public class CustomExceptionHandler
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<CustomExceptionHandler> _logger;
		public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
		{
			_next = next;
			_logger = logger;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);

				// Only handle 404 if the response status code is 404 and response hasn't been written
				if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
				{
					await HandleNotFound(context);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				await HandleException(context, ex);
			}
		}

		private static async Task HandleException(HttpContext context, Exception ex)
		{
			if (context.Response.HasStarted)
			{
				return;
			}

			context.Response.StatusCode = ex switch
			{
				NotFoundException _ => StatusCodes.Status404NotFound,
				NotAuthorizedException _ => StatusCodes.Status401Unauthorized,
				ConflictException _ => StatusCodes.Status409Conflict,
				CustomBadRequest _ => StatusCodes.Status406NotAcceptable,
				_ => StatusCodes.Status500InternalServerError
			};

			var response = new ErrorModel()
			{
				StatusCode = context.Response.StatusCode,
				ErrorMessage = ex.Message
			};
			await context.Response.WriteAsJsonAsync(response);
		}

		private static async Task HandleNotFound(HttpContext context)
		{
			var response = new ErrorModel()
			{
				StatusCode = StatusCodes.Status404NotFound,
				ErrorMessage = $"EndPoint {context.Request.Path} is not found"
			};
			await context.Response.WriteAsJsonAsync(response);
		}
	}
}
