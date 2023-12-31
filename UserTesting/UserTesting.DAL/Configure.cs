﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserTesting.DAL.Data;
using UserTesting.DAL.Repositories;
using UserTesting.DAL.UnitOfWorks;

namespace UserTesting.DAL;

public static class Configure
{
	public static void ConfigureDataAccessLayerServices(this IServiceCollection services, string connectionString)
	{
		// Add DbContext
		services.AddDbContextPool<UserTestingDbContext>(options =>
			options.UseSqlServer(connectionString));

		// Add Services
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<ITestRepository, TestRepository>();
	}
}
