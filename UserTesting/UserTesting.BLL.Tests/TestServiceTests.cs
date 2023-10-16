using AutoMapper;
using Moq;
using UserTesting.BLL.DTOs;
using UserTesting.BLL.Exceptions;
using UserTesting.BLL.Services;
using UserTesting.DAL.Entities;
using UserTesting.DAL.UnitOfWorks;

namespace UserTesting.BLL.Tests;

[TestFixture]
public class TestServiceTests
{
	private Mock<IUnitOfWork> _unitOfWorkMock;
	private Mock<IMapper> _mapperMock;
	private TestService _testService;

	[SetUp]
	public void Setup()
	{
		_unitOfWorkMock = new Mock<IUnitOfWork>();
		_mapperMock = new Mock<IMapper>();
		_testService = new TestService(_unitOfWorkMock.Object, _mapperMock.Object);
	}

	[Test]
	public async Task GetNotAnsweredAsync_Returns_Unpassed_Test()
	{
		// Arrange
		var user = new User { Id = "someId" };
		var testId = Guid.NewGuid();

		var userTest = new UserTest
		{
			UserId = user.Id,
			TestId = testId,
			Passed = false
		};

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testId))
			.ReturnsAsync(new Test());
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testId))
			.ReturnsAsync(userTest);
		_mapperMock.Setup(x => x.Map<TestWithoutAnswersDto>(userTest.Test))
			.Returns(new TestWithoutAnswersDto { Id = testId });

		// Act
		var result = await _testService.GetNotAnsweredAsync(user, testId);

		// Assert
		Assert.That(result.Id, Is.EqualTo(testId));
		_unitOfWorkMock.Verify(x => x.UserTestRepository.GetAsync(user.Id, testId), Times.Once);
		_mapperMock.Verify(x => x.Map<TestWithoutAnswersDto>(userTest.Test), Times.Once);
	}

	[Test]
	public void GetNotAnsweredAsync_Throws_UserHasNoAccessToTestException_For_Non_Existent_UserTest()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "user1" };
		var testId = Guid.NewGuid();

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testId))
			.ReturnsAsync(new Test());
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testId))
			.ReturnsAsync((UserTest)null);

		// Act & Assert
		var ex = Assert.ThrowsAsync<UserHasNoAccessToTestException>(
			async () => await _testService.GetNotAnsweredAsync(user, testId));

		Assert.That(ex.Message, Is.EqualTo($"Username {user.UserName} has no acces to test with id {testId}"));
	}

	[Test]
	public void GetNotAnsweredAsync_Throws_UserAlreadyPassedTestException_For_Passed_Test()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "user1" };
		var testId = Guid.NewGuid();

		var userTest = new UserTest
		{
			UserId = user.Id,
			TestId = testId,
			Passed = true
		};

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testId))
			.ReturnsAsync(new Test());
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testId))
			.ReturnsAsync(userTest);

		// Act & Assert
		var ex = Assert.ThrowsAsync<UserAlreadyPassedTestException>(
			async () => await _testService.GetNotAnsweredAsync(user, testId));

		Assert.That(ex.Message, Is.EqualTo($"Username {user.UserName} has already passed test with id {testId}"));
	}

	[Test]
	public void GetNotAnsweredAsync_Throws_TestNotFoundException_For_Non_Existent_Test()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "user1" };
		var testId = Guid.NewGuid();

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testId))
			.ReturnsAsync((Test)null);

		// Act & Assert
		var ex = Assert.ThrowsAsync<TestNotFoundException>(
			async () => await _testService.GetNotAnsweredAsync(user, testId));

		Assert.That(ex.Message, Is.EqualTo($"Test not found with id {testId}"));
	}

	[Test]
	public async Task GetAllAsignedUserTestsAsync_Returns_UserTestDtoList_For_Valid_User()
	{
		// Arrange
		var user = new User { Id = Guid.NewGuid().ToString() };

		var userTests = new List<UserTest>
		{
			new UserTest { UserId = user.Id, TestId = Guid.NewGuid(), Passed = false, Test = new Test { Name = "Name1" } },
			new UserTest { UserId = user.Id, TestId = Guid.NewGuid(), Passed = false, Test = new Test { Name = "Name2" }  },
			new UserTest { UserId = user.Id, TestId = Guid.NewGuid(), Passed = true, Test = new Test { Name = "Name3" }  }
		};

		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAllByUserIdAsync(user.Id))
			.ReturnsAsync(userTests);

		var userTestDtos = new List<UserTestDto>
		{
			new UserTestDto { TestId = userTests[0].TestId, Passed = userTests[0].Passed, Mark = userTests[0].Mark, Name = userTests[0].Test.Name },
			new UserTestDto { TestId = userTests[1].TestId, Passed = userTests[1].Passed, Mark = userTests[1].Mark, Name = userTests[1].Test.Name },
			new UserTestDto { TestId = userTests[2].TestId, Passed = userTests[2].Passed, Mark = userTests[2].Mark, Name = userTests[2].Test.Name }
		};

		_mapperMock.Setup(x => x.Map<List<UserTestDto>>(userTests)).Returns(userTestDtos);

		// Act
		var resultTestList = await _testService.GetAllAsignedUserTestsAsync(user);
		Assert.Multiple(() =>
		{

			// Assert
			Assert.That(resultTestList.Count(), Is.EqualTo(userTestDtos.Count));
			Assert.That(resultTestList, Is.EqualTo(userTestDtos));
		});
	}

	[Test]
	public void GetAllAsignedUserTestsAsync_Throws_UserHasNoAssignedTestsException_For_No_Tests_Exist()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "user1" };

		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAllByUserIdAsync(user.Id))
			.ReturnsAsync((List<UserTest>)null);

		// Act & Assert
		var ex = Assert.ThrowsAsync<UserHasNoAssignedTestsException>(
			async () => await _testService.GetAllAsignedUserTestsAsync(user));

		Assert.That(ex.Message, Is.EqualTo($"User {user.UserName} has no assigned tests"));
	}

	[Test]
	public async Task PassAsync_Marks_User_Test_As_Passed()
	{
		// Arrange
		var user = new User { Id = "userId", UserName = "userName" };
		var testId = Guid.NewGuid();

		var testAnswersDto = new TestAnswersDto
		{
			TestId = testId,
			Answers = new List<TestAnswersDto.AnswerDto>
		{
			new TestAnswersDto.AnswerDto { QuestionOrdinal = 1, AnswerOrdinal = 1 }
		}
		};

		var userTest = new UserTest
		{
			UserId = user.Id,
			TestId = testId,
			Passed = false,
			Test = new Test
			{
				Questions = new List<Question>
				{
				   new Question { Ordinal = 1, Options = new List<Option> { new Option { Ordinal = 1} },Answer = new Option { Ordinal = 1 } }
				}
			}
		};

		var userTestDto = new UserTestDto
		{
			TestId = userTest.TestId,
			Passed = true,
			Mark = 1.0m,
			Name = userTest.Test.Name
		};

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testId))
			.ReturnsAsync(new Test());
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testId)).ReturnsAsync(userTest);
		_unitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);
		_mapperMock.Setup(x => x.Map<UserTestDto>(userTest)).Returns(userTestDto);

		// Act
		var result = await _testService.PassAsync(user, testAnswersDto);
		Assert.Multiple(() =>
		{

			// Assert
			Assert.That(result.Passed, Is.True);
			Assert.That(result.Mark, Is.EqualTo(1.0m));
		});
		_unitOfWorkMock.Verify(x => x.SaveAsync(), Times.Once);
		_mapperMock.Verify(x => x.Map<UserTestDto>(userTest), Times.Once);
	}

	[Test]
	public void PassAsync_Throws_UserHasNoAccessToTestException_For_Null_UserTest()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "userName" };
		var testAnswersDto = new TestAnswersDto { TestId = Guid.NewGuid(), Answers = new List<TestAnswersDto.AnswerDto>() };

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testAnswersDto.TestId))
			.ReturnsAsync(new Test());
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testAnswersDto.TestId)).ReturnsAsync((UserTest)null);

		// Act & Assert
		var ex = Assert.ThrowsAsync<UserHasNoAccessToTestException>(
			async () => await _testService.PassAsync(user, testAnswersDto));

		Assert.That(ex.Message, Is.EqualTo($"Username {user.UserName} has no acces to test with id {testAnswersDto.TestId}"));
	}

	[Test]
	public void PassAsync_Throws_UserAlreadyPassedTestException_For_Passed_UserTest()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "userName" };
		var testId = Guid.NewGuid();
		var userTest = new UserTest { UserId = user.Id, TestId = testId, Passed = true };

		var testAnswersDto = new TestAnswersDto { TestId = testId, Answers = new List<TestAnswersDto.AnswerDto>() };

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testAnswersDto.TestId))
			.ReturnsAsync(new Test());
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testId)).ReturnsAsync(userTest);

		// Act & Assert
		var ex = Assert.ThrowsAsync<UserAlreadyPassedTestException>(
			async () => await _testService.PassAsync(user, testAnswersDto));

		Assert.That(ex.Message, Is.EqualTo($"Username {user.UserName} has already passed test with id {testId}"));
	}

	[Test]
	public void PassAsync_Throws_TestNotFoundException_For_Null_Test()
	{
		// Arrange
		var user = new User { Id = "user1", UserName = "userName" };
		var testId = Guid.NewGuid();
		var userTest = new UserTest { UserId = user.Id, TestId = testId, Passed = false, Test = null };

		var testAnswersDto = new TestAnswersDto { TestId = testId, Answers = new List<TestAnswersDto.AnswerDto>() };

		_unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(testId))
			.ReturnsAsync((Test)null);
		_unitOfWorkMock.Setup(x => x.UserTestRepository.GetAsync(user.Id, testId)).ReturnsAsync(userTest);

		// Act & Assert
		var ex = Assert.ThrowsAsync<TestNotFoundException>(
			async () => await _testService.PassAsync(user, testAnswersDto));

		Assert.That(ex.Message, Is.EqualTo($"Test not found with id {testId}"));
	}
}
