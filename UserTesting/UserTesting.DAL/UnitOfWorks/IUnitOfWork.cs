using UserTesting.DAL.Repositories;

namespace UserTesting.DAL.UnitOfWorks;

// don't realy need it, just to showcase knowlage of this pattern
public interface IUnitOfWork : IDisposable 
{
	ITestRepository TestRepository { get; }

	IUserTestRepository UserTestRepository { get; }

	Task SaveAsync();
}
