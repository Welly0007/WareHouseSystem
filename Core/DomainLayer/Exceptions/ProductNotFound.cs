namespace DomainLayer.Exceptions
{
	public sealed class ProductNotFound : NotFoundException
	{
		public ProductNotFound(int id) : base($"Product with id {id} was not found.")
		{
		}
		public ProductNotFound(string message) : base(message)
		{
		}
	}
}
