using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.BasketModuleDtos
{
	public class BasketItemDto
	{
		public int Id { get; set; }
		public string ProductName { get; set; } = default!;
		public string PictureUrl { get; set; } = default!;
		[Range(0, 100)]
		public int Quanity { get; set; }
		[Range(0, double.MaxValue)]
		public decimal Price { get; set; }

	}
}
