using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserTesting.API.Models;
using UserTesting.BLL.Services;
using UserTesting.DAL.Entities;

namespace UserTesting.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly UserManager<User> userManager;
	private readonly ITokenService tokenRepository;

	public AuthController(UserManager<User> userManager, ITokenService tokenRepository)
	{
		this.userManager=userManager;
		this.tokenRepository=tokenRepository;
	}

	[HttpPost]
	[Route("Login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
	{
		var user = await userManager.FindByEmailAsync(loginRequest.Email);

		if (user != null)
		{
			var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequest.Password);

			if (checkPasswordResult)
			{
				var roles = await userManager.GetRolesAsync(user);

				if (roles != null)
				{
					var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());

					var loginResponce = new LoginResponce()
					{
						JwtToken = jwtToken
					};

					return Ok(loginResponce);
				}

			}
		}

		return BadRequest("Username or password incorrect");
	}
}
