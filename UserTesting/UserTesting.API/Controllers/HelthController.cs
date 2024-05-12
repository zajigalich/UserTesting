using Microsoft.AspNetCore.Mvc;

namespace UserTesting.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
	[HttpGet]
	public IActionResult HealthCheck()
	{
		return Ok();
	}
}
