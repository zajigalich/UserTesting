using Microsoft.EntityFrameworkCore;
using UserTesting.DAL.Data;
using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Repositories;

public class UserTestRepository : IUserTestRepository
{
	private readonly UserTestingDbContext _dbContext;

	public UserTestRepository(UserTestingDbContext dbContext)
    {
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<UserTest>> GetAllByUserIdAsync(string userId)
	{
		return await _dbContext.UserTests
					.Include(ut => ut.Test)
					.Where(ut => ut.UserId == userId)
					.ToListAsync();
	}

	public async Task<UserTest?> GetAsync(string userId, Guid testId)
	{
		return await _dbContext.UserTests
			.Include (ut => ut.Test)
			.Where (ut => ut.UserId == userId)
			.Where (ut => ut.TestId == testId)
			.FirstOrDefaultAsync();
	}
}
