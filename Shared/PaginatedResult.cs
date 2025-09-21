namespace Shared
{
	public class PaginatedResult<TEnity>
	{
		public PaginatedResult(int pageIndex, int pageSize, int totalFoundItems, IEnumerable<TEnity> data)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			Data = data;
			TotalFoundItems = totalFoundItems;
			TotalPages = totalFoundItems != 0 ? (int)Math.Ceiling(totalFoundItems / (double)pageSize) : 0;
		}
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int TotalFoundItems { get; set; }
		public IEnumerable<TEnity> Data { get; set; }
	}
}
