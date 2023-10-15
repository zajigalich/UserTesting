using Microsoft.EntityFrameworkCore;
using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Data;

internal static class DataSeedModelBuilderExtensions
{
	public static void SeedTests(this ModelBuilder modelBuilder)
	{
		var tests = new List<Test>
		{
			new Test
			{
				Id = Guid.NewGuid(),
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
				Id = Guid.NewGuid(),
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
			}
		};

		modelBuilder.Entity<Test>().HasData(tests);
	}
}
