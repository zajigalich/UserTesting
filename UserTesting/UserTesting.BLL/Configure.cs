using Microsoft.Extensions.DependencyInjection;
using UserTesting.BLL.Services;

namespace UserTesting.BLL;

public static class Configure
{
	public static void ConfigureBusinessLogicLayerServices(this IServiceCollection services)
	{
		// Add Services
		services.AddScoped<ITokenService, TokenService>();
	}
}
