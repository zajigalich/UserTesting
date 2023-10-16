﻿using UserTesting.DAL.Data;
using UserTesting.DAL.Repositories;

namespace UserTesting.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private bool _disposed;
	private ITestRepository _testRepository;

    public UnitOfWork(UserTestingDbContext dbContext)
    {
		DbContext=dbContext;
	}

	public ITestRepository TestRepository => _testRepository ??= new TestRepository(DbContext);

	protected UserTestingDbContext DbContext { get; }

	public async Task SaveAsync()
	{
		await DbContext.SaveChangesAsync();
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				DbContext.Dispose();
			}
		}

		_disposed = true;
	}
}
