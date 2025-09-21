using System.Text.Json.Serialization;
using Warehouse.Web.CustomMiddleWares;

namespace Warehouse.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region Add services to the container
			builder.Services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				});
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddApplicationService(builder.Configuration);
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAngular", policy =>
				{
					policy.WithOrigins("http://localhost:4200")
						  .AllowAnyHeader()
						  .AllowAnyMethod();
				});
			});
			#endregion

			var app = builder.Build();


			#region SeedingData
			//var scope = app.Services.CreateScope();
			//var objectDataSeeding = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
			//objectDataSeeding.SeedDataAsync();
			#endregion

			#region Configure the HTTP request pipeline
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCors("AllowAngular");
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseMiddleware<CustomExceptionHandler>();

			app.MapControllers();
			#endregion

			app.Run();
		}
	}
}
