using AutoMapper;
using LoginBackend.Application.Requests;
using LoginBackend.Application.Responses;
using LoginBackend.Domain.Entities;

namespace LoginBackend.Api.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddStudentRequest, Student>().ReverseMap();
        CreateMap<GetStudentResponse, Student>().ReverseMap();
    }
}
