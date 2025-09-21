namespace Shared.DataTransferObjects.BasketModuleDtos
{
	public class CustomerBasketDto
	{
		public string Id { get; set; } = default!;
		public ICollection<BasketItemDto> Items { get; set; } = [];
	}
}
