using Microsoft.EntityFrameworkCore;
using UserTesting.DAL.Data;
using UserTesting.DAL.Entities;
using UserTesting.DAL.Repositories;

namespace UserTesting.DAL.Tests;

[TestFixture]
public class DALTests
{
	private UserTestingDbContext _dbContext;

	[SetUp]
	public void Setup()
	{
		// Setup an in-memory database for testing
		var options = new DbContextOptionsBuilder<UserTestingDbContext>()
			.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
			.Options;

		_dbContext = new UserTestingDbContext(options);

		_dbContext.Database.EnsureCreated();
	}

	[TearDown]
	public void TearDown()
	{
		_dbContext.Database.EnsureDeleted();
		_dbContext.Dispose();
	}

	[Test]
	[TestCaseSource(nameof(GetTestsData))]
	public async Task Test_GetByIdAsync_Returns_Expected_Test(Test expectedTest)
	{
		// Arrange
		var testRepo = new TestRepository(_dbContext);

		// Act
		var resultTest = await testRepo.GetByIdAsync(expectedTest.Id);

		// Assert
		Assert.That(resultTest, Is.Not.Null);
		Assert.That(resultTest?.Id, Is.EqualTo(expectedTest.Id));

		var comparer = new ObjectComparer();
		comparer.Compare(expectedTest, resultTest);
	}

	[Test]
	//[TestCaseSource(nameof(GetUserTestsData))]
	public async Task UserTest_GetAllByUserIdAsync_Returns_All_UserTests_For_Given_User()
	{
		// Arrange
		var userId = "11bac029-c18b-40dd-baca-2854e731149f";
		var userTestRepo = new UserTestRepository(_dbContext);

		// Act
		var userTests = (await userTestRepo.GetAllByUserIdAsync(userId)).ToList();

		// Assert
		Assert.That(userTests.Count, Is.EqualTo(3));
		Assert.That(userTests.TrueForAll(ut => ut.UserId == userId), Is.True);
	}

	[Test]
	[TestCaseSource(nameof(GetUserTestsData))]
	public async Task UserTest_GetAsync_Returns_Expected_UserTest_For_Given_User_Test(UserTest expectedUserTest)
	{
		// Arrange
		var userTestRepo = new UserTestRepository(_dbContext);

		// Act
		var userTest = await userTestRepo.GetAsync(expectedUserTest.UserId, expectedUserTest.TestId);

		// Assert
		Assert.That(userTest, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(userTest?.UserId, Is.EqualTo(expectedUserTest.UserId));
			Assert.That(userTest?.TestId, Is.EqualTo(expectedUserTest.TestId));
		});

		var comparer = new ObjectComparer();
		comparer.Compare(expectedUserTest, userTest);
	}

	private static IEnumerable<UserTest> GetUserTestsData()
	{
		var userTests = new List<UserTest>
		{
			new UserTest { UserId = "11bac029-c18b-40dd-baca-2854e731149f", TestId = Guid.Parse("ba4dfdda-e505-402e-8be2-d2c619974c9e"), Mark = 0.8m, Passed = true },
			new UserTest { UserId = "11bac029-c18b-40dd-baca-2854e731149f", TestId = Guid.Parse("2cbae21d-0651-4609-b77c-a0d69af10349"), Mark = 0.3m, Passed = true },
			new UserTest { UserId = "11bac029-c18b-40dd-baca-2854e731149f", TestId = Guid.Parse("591928f1-0e0a-4e7b-8b9d-e5c7a7791974") },

			new UserTest { UserId = "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9", TestId = Guid.Parse("591928f1-0e0a-4e7b-8b9d-e5c7a7791974") },
			new UserTest { UserId = "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9", TestId = Guid.Parse("0ccda22e-372a-48ef-afc6-9dc8b41007e1") },
		};
		return userTests;
	}

	private static IEnumerable<Test> GetTestsData()
	{
		var tests = new List<Test>
		{
			new Test
			{
				Id = Guid.Parse("ba4dfdda-e505-402e-8be2-d2c619974c9e"),
				Name = "Test 1",
				Description = "This is Test 1",
				Questions = new List<Question>
				{
					new Question
					{
						Ordinal = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 2, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 1, Text = "Option 1" }
					},
					new Question
					{
						Ordinal = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 2, Text = "Option 2" }
					},
					new Question
					{
						Ordinal = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 3, Text = "Option 3" }
					},
				}
			},
			new Test
			{
				Id = Guid.Parse("2cbae21d-0651-4609-b77c-a0d69af10349"),
				Name = "Test 2",
				Description = "This is Test 2",
				Questions = new List<Question>
				{
					new Question
					{
						Ordinal = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 2, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 1, Text = "Option 1" }
					},
					new Question
					{
						Ordinal = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 2, Text = "Option 2" }
					},
					new Question
					{
						Ordinal = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 3, Text = "Option 3" }
					},
				}
			},
			new Test
			{
				Id = Guid.Parse("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
				Name = "Test 3",
				Description = "This is Test 3",
				Questions = new List<Question>
				{
					new Question
					{
						Ordinal = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 2, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 1, Text = "Option 1" }
					},
					new Question
					{
						Ordinal = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 2, Text = "Option 2" }
					},
					new Question
					{
						Ordinal = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 3, Text = "Option 3" }
					},
				}
			},
			new Test
			{
				Id = Guid.Parse("0ccda22e-372a-48ef-afc6-9dc8b41007e1"),
				Name = "Test 4",
				Description = "This is Test 4",
				Questions = new List<Question>
				{
					new Question
					{
						Ordinal = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 2, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 1, Text = "Option 1" }
					},
					new Question
					{
						Ordinal = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 2, Text = "Option 2" }
					},
					new Question
					{
						Ordinal = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Ordinal = 1, Text = "Option 1" },
							new Option { Ordinal = 2, Text = "Option 2" },
							new Option { Ordinal = 3, Text = "Option 3" },
						},
						Answer = new Option { Ordinal = 3, Text = "Option 3" }
					},
				}
			}
		};

		return tests;
	}
}
