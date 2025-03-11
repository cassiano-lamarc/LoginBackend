using AutoMapper;
using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Responses.Students;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class GetStudentByIdUseCase : StudentBaseUseCase, IGetStudentByIdUseCase
{
    IMapper _mapper;

    public GetStudentByIdUseCase(IMapper mapper, IStudentRepository repository) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<GetStudentResponse> Handler(int id)
    {
        var student = (await _repository.Get(id)).FirstOrDefault();
        if (student == null)
            throw new CustomException("Student not found");

        return _mapper.Map<GetStudentResponse>(student);
    }
}
