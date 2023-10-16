using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Net;
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

	public TestsController(UserManager<User> userManager, ITestService testService, UserTestingDbContext dbContext)
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

		var userTestsDtos = await _testService.GetNotAnsweredAssignedToUser(user);

		return Ok(userTestsDtos);
	}
}
