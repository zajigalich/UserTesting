using UserTesting.DAL.Entities;

namespace UserTesting.BLL.Services;

public interface ITokenService
{
	string CreateJwtToken(User user, List<string> roles);
}
