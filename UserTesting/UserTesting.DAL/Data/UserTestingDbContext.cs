using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Data;

public class UserTestingDbContext : IdentityDbContext<User>
{
	public UserTestingDbContext(DbContextOptions<UserTestingDbContext> dbContextOptions)
		: base(dbContextOptions)
	{
	}

	public DbSet<Test> Tests { get; set; }

	public DbSet<UserTest> UserTests { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Many to many config (User - Test)
		modelBuilder.Entity<UserTest>()
			.HasOne(ut => ut.User)
			.WithMany(u => u.UserTests)
			.HasForeignKey(ut => ut.UserId);

		modelBuilder.Entity<UserTest>()
			.HasOne(ut => ut.Test)
			.WithMany(t => t.UserTests)
			.HasForeignKey(ut => ut.TestId);

		modelBuilder.Entity<Test>()
			.HasMany(t => t.Users)
			.WithMany(u => u.Tests)
			.UsingEntity<UserTest>();

		// Serializing questions as json string in Test entity
		modelBuilder.Entity<Test>().Property(t => t.Questions)
				.HasConversion(
					v => JsonConvert.SerializeObject(v),
					v => JsonConvert.DeserializeObject<List<Question>>(v));

		// Not using some props from Identity user class
		modelBuilder.Entity<User>()
				.Ignore(c => c.AccessFailedCount)
				.Ignore(c => c.LockoutEnabled)
				.Ignore(c => c.LockoutEnd)
				.Ignore(c => c.TwoFactorEnabled)
				.Ignore(c => c.PhoneNumber)
				.Ignore(c => c.PhoneNumberConfirmed)
				.Ignore(c => c.AccessFailedCount)
				.Ignore(c => c.EmailConfirmed);

		// Seed Tests, Users and TestUsers
		modelBuilder.SeedData();
	}
}
