using AutoMapper;
using UserTesting.BLL.DTOs;
using UserTesting.BLL.Exceptions;
using UserTesting.DAL.Entities;
using UserTesting.DAL.UnitOfWorks;

namespace UserTesting.BLL.Services;

public class TestService : ITestService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public TestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

    public async Task<IEnumerable<UserTestDto>> GetAllAsignedUserTestsAsync(User user)
	{
		var tests = await _unitOfWork.UserTestRepository.GetAllByUserIdAsync(user.Id)
			?? throw new UserHasNoAssignedTestsException(user.UserName);

		return _mapper.Map<List<UserTestDto>>(tests);
	}

	public async Task<TestWithoutAnswersDto> GetNotAnsweredAsync(User user, Guid testId)
	{
		await VerifyTestExistsAsync(testId);

		var userTest = await _unitOfWork.UserTestRepository.GetAsync(user.Id, testId)
			?? throw new UserHasNoAccessToTestException(user.UserName, testId);

		VerifyTestIsNotPassed(user, testId, userTest);

		return _mapper.Map<TestWithoutAnswersDto>(userTest.Test);
	}

	private static void VerifyTestIsNotPassed(User user, Guid testId, UserTest userTest)
	{
		if (userTest.Passed)
		{
			throw new UserAlreadyPassedTestException(user.UserName, testId);
		}
	}

	private async Task VerifyTestExistsAsync(Guid testId)
	{
		_ = await _unitOfWork.TestRepository.GetByIdAsync(testId)
					?? throw new TestNotFoundException(testId);
	}
}
