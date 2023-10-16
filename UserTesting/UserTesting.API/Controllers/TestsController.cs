using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Net;
using UserTesting.BLL.DTOs;
using UserTesting.BLL.Services;
using UserTesting.DAL.Data;
using UserTesting.DAL.Entities;

namespace UserTesting.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
	private readonly UserManager<User> _userManager;
	private readonly ITestService _testService;

	public TestsController(UserManager<User> userManager, ITestService testService)
    {
		_userManager = userManager;
		_testService = testService;
	}

	[HttpGet]
	[Authorize]
	[OutputCache]
	public async Task<IActionResult> GetAssigned()
	{
		var user = await _userManager.GetUserAsync(User);

		if (user == null)
		{
			return Unauthorized();
		}

		var userTestsDtos = await _testService.GetAllAsignedUserTestsAsync(user);

		return Ok(userTestsDtos);
	}

	[HttpGet("{testId:Guid}")]
	[Authorize]
	[OutputCache]
	public async Task<IActionResult> Get([FromRoute] Guid testId)
	{
		var user = await _userManager.GetUserAsync(User);

		if (user == null)
		{
			return Unauthorized();
		}

		var test = await _testService.GetNotAnsweredAsync(user, testId);

		return Ok(test);
	}

	[HttpPost("pass/{testId:Guid}")]
	[Authorize]
	public async Task<IActionResult> Pass([FromRoute] Guid testId)
	{
		return Ok();
	}
}
