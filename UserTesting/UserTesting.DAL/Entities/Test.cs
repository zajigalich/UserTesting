using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UserTesting.DAL.Entities;

public class Test
{
	[Key]
	public Guid Id { get; set; }

	[NotNull]
	[MaxLength(50)]
	public string Name { get; set; }

	[NotNull]
	[MaxLength(250)]
	public string Description { get; set; }

	[NotNull]
	public List<Question> Questions { get; set; }


	// Navigational props
	public virtual ICollection<UserTest> UserTests { get; set; }

	// Skipping props
	public virtual ICollection<User> Users { get; set; }
}
