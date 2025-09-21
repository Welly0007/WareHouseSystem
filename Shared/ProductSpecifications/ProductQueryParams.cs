using System.ComponentModel;

namespace Shared.ProductSpecifications
{
	public class ProductQueryParams
	{
		const int maxPageSize = 100;

		public int? CategoryId { get; set; }
		public int? WarehouseId { get; set; }

		private int _pageIndex = 1;
		[DefaultValue(1)]
		public int pageIndex
		{
			get { return _pageIndex; }
			set
			{
				if (value <= 0)
				{
					_pageIndex = 1;
				}
				else
				{
					_pageIndex = value;
				}
			}
		}

		private int _pageSize = 10;
		[DefaultValue(10)]
		public int pageSize
		{
			get { return _pageSize; }
			set
			{
				if (value > maxPageSize)
				{
					_pageSize = maxPageSize;
				}
				else if (value <= 0)
				{
					_pageSize = 5;
				}
				else
				{
					_pageSize = value;
				}
			}
		}

		public ProductSortingOptions sortOptions { get; set; }

		[DefaultValue(true)]
		public bool isSortDescending { get; set; } = true;

		public string? searchValue { get; set; }

		[DefaultValue(ProductSearchOptions.All)]
		public ProductSearchOptions searchOptions { get; set; } = ProductSearchOptions.All;
	}
}
