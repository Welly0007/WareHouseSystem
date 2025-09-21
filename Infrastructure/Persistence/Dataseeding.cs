using System.Text.Json;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence
{
	public class Dataseeding(AppDbContext _context) : IDataSeeding
	{
		public async Task SeedDataAsync()
		{
			try
			{
				if ((await _context.Database.GetPendingMigrationsAsync()).Any())
				{
					await _context.Database.MigrateAsync();
				}
				if (!_context.Products.Any())
				{
					var productsData = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\products.json");
					var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);
					if (products != null && products.Any())
					{
						await _context.Products.AddRangeAsync(products);
					}
				}
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				//TODO
				Console.WriteLine(ex.Message);
			}
		}
	}
}
