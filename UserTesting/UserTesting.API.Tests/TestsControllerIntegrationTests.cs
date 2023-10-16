using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using UserTesting.BLL.Services;
using UserTesting.DAL.Entities;

namespace UserTesting.API.Tests;

// I have tried to create some, but actualy I have no experience in integrational tests
[TestFixture]
public class TestsControllerIntegrationTests
{
	private WebApplicationFactory<Program> _factory;
	private HttpClient _client;
	private ITokenService _tokenService;

	[SetUp]
	public void SetUp()
	{
		_factory = new WebApplicationFactory<Program>();

		_client = _factory.CreateClient();

		var scope = _factory.Services.CreateScope();

		_tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
	}

	[Test]
	public async Task GetAssigned_ReturnsSuccessStatusCode()
	{
		// Arrange
		var client = _factory.CreateClient();

		var user = new User { Id = "11bac029-c18b-40dd-baca-2854e731149f", Email = "user1@example.com" };
		var roles = new List<string> { "User" };

		var jwtToken = _tokenService.CreateJwtToken(user, roles);

		client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

		// Act
		var response = await client.GetAsync("/api/Tests");

		// Assert
		Assert.That(response.IsSuccessStatusCode, Is.True);
	}
}