using Gamestore.BLL.Exceptions;
using System.Net;

namespace UserTesting.API.Middlewares;

public class AppExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public AppExceptionHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (AppException ex)
		{
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";

			var error = new
			{
				ErrorMessage = ex.Message,
			};

			await context.Response.WriteAsJsonAsync(error);
		}
		catch (Exception)
		{
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";

			var error = new
			{
				ErrorMessage = "Something went wrong! We are looking into resolving this."
			};

			await context.Response.WriteAsJsonAsync(error);
		}
	}
}
