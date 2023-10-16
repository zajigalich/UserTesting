using Microsoft.EntityFrameworkCore;
using UserTesting.DAL.Data;
using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Repositories;

public class TestRepository : ITestRepository
{
	private readonly UserTestingDbContext _dbContext;

	public TestRepository(UserTestingDbContext dbContext)
    {
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<Test>> GetAllByUserIdAsync(string userId)
	{
		return await _dbContext.UserTests
			.Include(ut => ut.Test)
			.Where(ut => ut.UserId == userId)
			.Select(ut => ut.Test)
			.ToListAsync();
	}

	public async Task<Test?> GetByIdAsync(Guid id)
	{
		return await _dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
	}
}
