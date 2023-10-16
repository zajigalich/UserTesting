using UserTesting.BLL.DTOs;
using UserTesting.DAL.Entities;

namespace UserTesting.BLL.Services;

public interface ITestService
{
	Task<IEnumerable<UserTestDto>> GetAllAsignedUserTestsAsync(User user);

	Task<TestWithoutAnswersDto> GetNotAnsweredAsync(User user, Guid testId);
}
