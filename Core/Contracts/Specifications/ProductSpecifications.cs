using System.Linq.Expressions;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Shared.ProductSpecifications;

namespace Service.Specifications
{
	public class ProductSpecifications : AbsSpecification<Product>
	{
		public ProductSpecifications(ProductQueryParams queryParams)
		{
			// Add includes for navigation properties

			if (!string.IsNullOrWhiteSpace(queryParams.searchValue))
			{
				var searchQuery = queryParams.searchValue.ToLower();

				switch (queryParams.searchOptions)
				{
					case ProductSearchOptions.ByName:
						Criteria = p => p.Name.ToLower().Contains(searchQuery);
						break;
					case ProductSearchOptions.All:
						Criteria = p => p.Name.ToLower().Contains(searchQuery);
						break;
				}
			}

			// Handle sorting
			Expression<Func<Product, object>> sortExpression = queryParams.sortOptions switch
			{
				ProductSortingOptions.Name => p => p.Name,
				ProductSortingOptions.Price => p => p.SellingPrice,
				_ => p => p.Id
			};

			AddOrderBy(sortExpression, queryParams.isSortDescending);
			Take = queryParams.pageSize;
			Skip = (queryParams.pageIndex - 1) * Take;
		}
		public ProductSpecifications(List<string> ids)
		{
			Criteria = p => ids.Contains(p.Id);
		}
	}
}
