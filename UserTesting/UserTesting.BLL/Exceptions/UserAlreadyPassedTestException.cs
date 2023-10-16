using Gamestore.BLL.Exceptions;

namespace UserTesting.BLL.Exceptions;

public class UserAlreadyPassedTestException : AppException
{
	public UserAlreadyPassedTestException(string username, Guid testId)
		: base($"Username {username} has already passed test with id {testId}")
	{
	}
}
