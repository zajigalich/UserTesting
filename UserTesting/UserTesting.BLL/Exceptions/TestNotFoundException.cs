using Gamestore.BLL.Exceptions;

namespace UserTesting.BLL.Exceptions;

public class TestNotFoundException : AppException
{
    public TestNotFoundException(Guid testId)
        : base($"Test not found with id {testId}")
    {
    }
}
