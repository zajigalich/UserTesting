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

		VerifyTestIsNotPassed(user, userTest);

		return _mapper.Map<TestWithoutAnswersDto>(userTest.Test);
	}

	public async Task<UserTestDto> PassAsync(User user, TestAnswersDto testAnswersDto)
	{
		await VerifyTestExistsAsync(testAnswersDto.TestId);

		var userTest = await _unitOfWork.UserTestRepository.GetAsync(user.Id, testAnswersDto.TestId)
			?? throw new UserHasNoAccessToTestException(user.UserName, testAnswersDto.TestId);

		VerifyTestIsNotPassed(user, userTest);

		userTest.Mark = CalculateMark(testAnswersDto, userTest.Test);
		userTest.Passed = true;

		await _unitOfWork.SaveAsync();

		return _mapper.Map<UserTestDto>(userTest);
	}

	private static decimal CalculateMark(TestAnswersDto testAnswersDto, Test test)
	{
		var totalQuestion = test.Questions.Count;
		var correctAnswers = 0;

		foreach (var question in test.Questions)
		{
			var answer = testAnswersDto.Answers.FirstOrDefault(a => a.QuestionOrdinal == question.Ordinal);

			if (answer == null)
			{
				continue;
			}

			bool isCorrect = answer.AnswerOrdinal == question.Answer.Ordinal;

			if (isCorrect)
			{
				correctAnswers++;
			}
		}

		decimal mark = (decimal)correctAnswers / totalQuestion;
		return mark;
	}

	private static void VerifyTestIsNotPassed(User user, UserTest userTest)
	{
		if (userTest.Passed)
		{
			throw new UserAlreadyPassedTestException(user.UserName, userTest.TestId);
		}
	}

	private async Task VerifyTestExistsAsync(Guid testId)
	{
		_ = await _unitOfWork.TestRepository.GetByIdAsync(testId)
					?? throw new TestNotFoundException(testId);
	}
}
