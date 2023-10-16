using UserTesting.DAL.Entities;

namespace UserTesting.BLL.Services;

public class TestService : ITestService
{
	public Task<IEnumerable<Test>> GetAssignedToUser(User user)
	{
		throw new NotImplementedException();
	}
}
