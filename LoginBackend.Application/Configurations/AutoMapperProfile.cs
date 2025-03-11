using AutoMapper;
using LoginBackend.Application.Requests;
using LoginBackend.Application.Responses.Students;
using LoginBackend.Domain.Entities;

namespace LoginBackend.Application.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddStudentRequest, Student>().ReverseMap();
        CreateMap<GetStudentResponse, Student>().ReverseMap();
    }
}
