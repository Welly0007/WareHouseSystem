namespace DomainLayer.Exceptions
{
	public class InvalidUserCreds(string message) : NotAuthorizedException(message)
	{
	}
}
