﻿using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Repositories;

public interface ITestRepository
{
	Task<Test?> GetByIdAsync(Guid id);
}
