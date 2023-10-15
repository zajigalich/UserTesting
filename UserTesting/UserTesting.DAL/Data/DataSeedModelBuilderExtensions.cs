using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Data;

internal static class DataSeedModelBuilderExtensions
{
	public static void SeedData(this ModelBuilder modelBuilder)
	{
		var testsIds = new List<Guid>
		{
			Guid.Parse("ba4dfdda-e505-402e-8be2-d2c619974c9e"),
			Guid.Parse("2cbae21d-0651-4609-b77c-a0d69af10349"),
			Guid.Parse("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
			Guid.Parse("0ccda22e-372a-48ef-afc6-9dc8b41007e1"),
		};
		var userIds = new List<string>
		{
			"11bac029-c18b-40dd-baca-2854e731149f",
			"bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
		};

		SeedUsers(modelBuilder, userIds);
		SeedTests(modelBuilder, testsIds);
		
		// Assigning users to tests
		SeedUserTests(modelBuilder, userIds, testsIds);
	}

	private static void SeedUserTests(ModelBuilder modelBuilder, List<string> userIds, List<Guid> testsIds)
	{
		var userTests = new List<UserTest>
		{
			new UserTest { UserId = userIds[0], TestId = testsIds[0] },
			new UserTest { UserId = userIds[0], TestId = testsIds[1] },
			new UserTest { UserId = userIds[0], TestId = testsIds[2] },

			new UserTest { UserId = userIds[1], TestId = testsIds[2] },
			new UserTest { UserId = userIds[1], TestId = testsIds[3] },
		};

		modelBuilder.Entity<UserTest>().HasData(userTests);
	}

	private static void SeedUsers(ModelBuilder modelBuilder, List<string> userIds)
	{
		var users = new List<User>
		{
			new User
			{
				Id = userIds[0],
				UserName = "User1",
				NormalizedUserName = "USER1",
				Email = "user1@example.com",
				NormalizedEmail = "USER1@EXAMPLE.COM",
			},
			new User
			{
				Id = userIds[1],
				UserName = "User2",
				NormalizedUserName = "USER2",
				Email = "user2@example.com",
				NormalizedEmail = "USER2@EXAMPLE.COM"
			},
		};

		PasswordHasher<User> ph = new();
		users[0].PasswordHash = ph.HashPassword(user: users[0], "user1");
		users[1].PasswordHash = ph.HashPassword(user: users[1], "user2");

		modelBuilder.Entity<User>().HasData(users);
	}

	private static void SeedTests(ModelBuilder modelBuilder, List<Guid> testsIds)
	{
		var tests = new List<Test>
		{
			new Test
			{
				Id = testsIds[0],
				Name = "Test 1",
				Description = "This is Test 1",
				Questions = new List<Question>
				{
					new Question
					{
						Number = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 2, Text = "Option 3" },
						},
						Answer = new Option { Number = 1, Text = "Option 1" }
					},
					new Question
					{
						Number = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 2, Text = "Option 2" }
					},
					new Question
					{
						Number = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 3, Text = "Option 3" }
					},
				}
			},
			new Test
			{
				Id = testsIds[1],
				Name = "Test 2",
				Description = "This is Test 2",
				Questions = new List<Question>
				{
					new Question
					{
						Number = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 2, Text = "Option 3" },
						},
						Answer = new Option { Number = 1, Text = "Option 1" }
					},
					new Question
					{
						Number = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 2, Text = "Option 2" }
					},
					new Question
					{
						Number = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 3, Text = "Option 3" }
					},
				}
			},
			new Test
			{
				Id = testsIds[2],
				Name = "Test 3",
				Description = "This is Test 3",
				Questions = new List<Question>
				{
					new Question
					{
						Number = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 2, Text = "Option 3" },
						},
						Answer = new Option { Number = 1, Text = "Option 1" }
					},
					new Question
					{
						Number = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 2, Text = "Option 2" }
					},
					new Question
					{
						Number = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 3, Text = "Option 3" }
					},
				}
			},
			new Test
			{
				Id = testsIds[3],
				Name = "Test 4",
				Description = "This is Test 4",
				Questions = new List<Question>
				{
					new Question
					{
						Number = 1,
						Text = "Question 1",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 2, Text = "Option 3" },
						},
						Answer = new Option { Number = 1, Text = "Option 1" }
					},
					new Question
					{
						Number = 2,
						Text = "Question 2",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 2, Text = "Option 2" }
					},
					new Question
					{
						Number = 3,
						Text = "Question 3",
						Options = new List<Option>
						{
							new Option { Number = 1, Text = "Option 1" },
							new Option { Number = 2, Text = "Option 2" },
							new Option { Number = 3, Text = "Option 3" },
						},
						Answer = new Option { Number = 3, Text = "Option 3" }
					},
				}
			}
		};

		modelBuilder.Entity<Test>().HasData(tests);
	}
}
