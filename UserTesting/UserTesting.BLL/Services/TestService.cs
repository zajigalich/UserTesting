using AutoMapper;
using UserTesting.BLL.DTOs;
using UserTesting.DAL.Entities;
using UserTesting.DAL.UnitOfWorks;

namespace UserTesting.BLL.Services;

public class TestService : ITestService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public TestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

    public async Task<IEnumerable<TestWithoutAnswerDto>> GetNotAnsweredAssignedToUser(User user)
	{
		var tests = await _unitOfWork.TestRepository.GetAllByUserIdAsync(user.Id);

		return null;
	}
}
