using Gamestore.BLL.Exceptions;

namespace UserTesting.BLL.Exceptions;

public class UserHasNoAssignedTestsException : AppException
{
    public UserHasNoAssignedTestsException(string username)
        : base($"User {username} has no assigned tests")
    {
    }
}
