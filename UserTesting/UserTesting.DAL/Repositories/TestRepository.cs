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

	public async Task<Test?> GetByIdAsync(Guid id)
	{
		return await _dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
	}
}
