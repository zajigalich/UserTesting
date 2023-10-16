using UserTesting.BLL.DTOs;
using UserTesting.DAL.Entities;

namespace UserTesting.BLL.Services;

public interface ITestService
{
	Task<IEnumerable<TestWithoutAnswerDto>> GetNotAnsweredAssignedToUser(User user); 
}
