using Gamestore.BLL.Exceptions;

namespace UserTesting.BLL.Exceptions;

public class UserHasNoAssignedTests : AppException
{
    public UserHasNoAssignedTests(string username)
        : base($"User {username} has no assigned tests")
    {
    }
}
