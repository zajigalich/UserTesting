using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using UserTesting.API.Models;
using UserTesting.BLL.DTOs;
using UserTesting.BLL.Services;
using UserTesting.DAL.Entities;

namespace UserTesting.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
	private readonly UserManager<User> _userManager;
	private readonly ITestService _testService;
	private readonly IMapper _mapper;

	public TestsController(UserManager<User> userManager, ITestService testService, IMapper mapper)
    {
		_userManager = userManager;
		_testService = testService;
		_mapper = mapper;
	}

	[HttpGet]
	[Authorize]
	[OutputCache]
	public async Task<IActionResult> GetAssigned()
	{
		var user = await _userManager.GetUserAsync(User);

		var userTestsDtos = await _testService.GetAllAsignedUserTestsAsync(user);

		return Ok(userTestsDtos);
	}

	[HttpGet("{testId:Guid}")]
	[Authorize]
	[OutputCache]
	public async Task<IActionResult> Get([FromRoute] Guid testId)
	{
		var user = await _userManager.GetUserAsync(User);

		var test = await _testService.GetNotAnsweredAsync(user, testId);

		return Ok(test);
	}

	[HttpPost("pass/{testId:Guid}")]
	[Authorize]
	public async Task<IActionResult> Pass([FromRoute] Guid testId, [FromBody] PassTestRequest passTestRequest, IOutputCacheStore cacheStore)
	{
		var user = await _userManager.GetUserAsync(User);

		var testAnswersDto = _mapper.Map<TestAnswersDto>(passTestRequest);
		testAnswersDto.TestId = testId;

		var userTestDto = await _testService.PassAsync(user, testAnswersDto);

		await cacheStore.EvictByTagAsync("tag-all", default);

		return Ok(userTestDto);
	}
}
