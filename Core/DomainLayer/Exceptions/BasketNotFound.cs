namespace DomainLayer.Exceptions
{
	public class BasketNotFound(string key) : NotFoundException($"Basket with {key} not found")
	{
	}
}
