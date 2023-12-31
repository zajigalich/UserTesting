﻿using AutoMapper;
using UserTesting.API.Models;
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

        CreateMap<Test, TestWithoutAnswersDto>();
        CreateMap<Option, OptionDto>();
        CreateMap<Question, QuestionWithoutAnswerDto>();
        CreateMap<Question, QuestionDto>();

        CreateMap<PassTestRequest, TestAnswersDto>();
        CreateMap<PassTestRequest.Answer, TestAnswersDto.AnswerDto>();
    }
}
