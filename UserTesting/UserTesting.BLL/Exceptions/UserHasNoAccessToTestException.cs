using Gamestore.BLL.Exceptions;

namespace UserTesting.BLL.Exceptions;

public class UserHasNoAccessToTestException : AppException
{
    public UserHasNoAccessToTestException(string username, Guid testId)
        : base($"Username {username} has no acces to test with id {testId}")
    {
    }
}
