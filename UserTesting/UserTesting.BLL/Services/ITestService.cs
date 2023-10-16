using UserTesting.DAL.Entities;

namespace UserTesting.BLL.Services;

public interface ITestService
{
	Task<IEnumerable<Test>> GetAssignedToUser(User user); 
}
