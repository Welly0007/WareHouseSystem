using System.Text;
using DomainLayer.Contracts;
using DomainLayer.Models.UserModule;
using DomainLayer.Models.WarehouseModule;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Data;
using Persistence.Repositories;
using Service;
using ServiceAbstraction;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Warehouse.Web
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
		{
			// Add application services here, e.g.:
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			//services.AddScoped<IDataSeeding, Dataseeding>();

			services.AddScoped<ITokenService, TokenService>();

			// Register individual services that ServiceManager depends on
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
			services.AddScoped<IPartyService, PartyService>();
			
			// Register InventoryService specifically for InventoryTransaction
			services.AddScoped<InventoryService<InventoryTransaction, CreateInventoryTransactionDto, ViewInventoryTransactionDto, string>>();
			
			services.AddScoped<IServiceManager, ServiceManager>();

			// Use AddIdentityCore instead of AddIdentity for JWT-only APIs
			services.AddIdentityCore<User>(options =>
			{
				// Configure Identity options
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			})
			.AddRoles<Role>()
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();

			// Add CORS policy
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSwagger", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader();
				});
			});

			//services.AddScoped<PictureUrlResolver>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "WarehouseManagement",
					Description = "ASP.Net Core API",
					Contact = new OpenApiContact
					{
						Name = "Mohamed Salim",
						Email = "mohamed.salim.s007@gmail.com",
					}
				});

				// Configure Bearer Token Authorization
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' [space] and then your token in the text input below.\n\nExample: \"Bearer abc123\""
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
									{
										Type = ReferenceType.SecurityScheme,
										Id = "Bearer"
									}
							},
					Array.Empty<string>()
					}
				});
			});
			services.AddAutoMapper(cfg =>
			{
				cfg.AddMaps(typeof(Service.AssemblyReference).Assembly);
			});
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies();
			});

			#region Redis Connection - Commented out for migration testing
			//services.AddSingleton<IConnectionMultiplexer>(_ =>
			//{
			//	try
			//	{
			//		var options = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisConnectionString")!);
			//		options.AbortOnConnectFail = false;
			//		return ConnectionMultiplexer.Connect(options);
			//	}
			//	catch (Exception ex)
			//	{
			//		throw new Exception("Could not connect to Redis", ex);
			//	}
			//}); 
			#endregion

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidIssuer = configuration["AppSettings:Issuer"],
							ValidateAudience = true,
							ValidAudience = configuration["AppSettings:Audience"],
							ValidateLifetime = true,
							IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(configuration["AppSettings:SecretKey"]!)),
							ValidateIssuerSigningKey = true
						};
					});
			return services;
		}
	}
}
