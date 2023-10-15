using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace UserTesting.DAL.Entities;

[PrimaryKey(nameof(UserId), nameof(TestId))]
public class UserTest
{
	[NotNull]
	public string UserId { get; set; }

	[NotNull]
	public Guid TestId { get; set; }

	[Precision(5, 2)]
	[AllowNull]
	public decimal? Mark { get; set; }

	// Navigational props

	public virtual User User { get; set; }

	public virtual Test Test { get; set; }
}
