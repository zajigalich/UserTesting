using AutoMapper;
using UserTesting.BLL.DTOs;
using UserTesting.BLL.Exceptions;
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

    public async Task<IEnumerable<UserTestDto>> GetNotAnsweredAssignedToUserAsync(User user)
	{
		var tests = await _unitOfWork.UserTestRepository.GetAllByUserIdAsync(user.Id)
			?? throw new UserHasNoAssignedTestsException(user.UserName);

		var userTestDtos = _mapper.Map<List<UserTestDto>>(tests);

		return userTestDtos;
	}
}
