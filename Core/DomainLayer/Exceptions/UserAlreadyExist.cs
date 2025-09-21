namespace DomainLayer.Exceptions
{
	public class UserAlreadyExist(string message) : ConflictException(message)
	{
	}
}
