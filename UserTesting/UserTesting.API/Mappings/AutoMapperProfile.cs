using AutoMapper;
using UserTesting.BLL.DTOs;
using UserTesting.DAL.Entities;

namespace UserTesting.API.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserTest, UserTestDto>()
            .ForMember(
            dest => dest.Name,
            opt => opt.MapFrom(src => src.Test.Name)
            );
    }
}
