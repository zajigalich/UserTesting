using UserTesting.BLL.DTOs;
using UserTesting.DAL.Entities;

namespace UserTesting.BLL.Services;

public interface ITestService
{
	Task<IEnumerable<UserTestDto>> GetNotAnsweredAssignedToUserAsync(User user);
	Task<TestWithoutAnswersDto> GetNotAnsweredAsync(Guid id);
}
