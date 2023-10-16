using UserTesting.DAL.Entities;

namespace UserTesting.DAL.Repositories;

public interface IUserTestRepository
{
	Task<IEnumerable<UserTest>> GetAllByUserIdAsync(string userId);
}
