using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserTesting.DAL.Data;

namespace UserTesting.DAL;

public static class Configure
{
	public static void ConfigureDataAccessLayerServices(this IServiceCollection services, string connectionString)
	{
		// Add DbContext
		services.AddDbContextPool<UserTestingDbContext>(options =>
			options.UseSqlServer(connectionString));
	}
}
