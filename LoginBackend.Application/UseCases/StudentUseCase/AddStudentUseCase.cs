using AutoMapper;
using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class AddStudentUseCase : StudentBaseUseCase, IAddStudentUseCase
{
    private readonly IMapper _mapper;

    public AddStudentUseCase(IStudentRepository repository, IMapper mapper): base (repository)
    {
        _mapper = mapper;
    }

    public async Task<int> Handler(AddStudentRequest request)
    {
        var existingStudent = await _repository.Get(null, request.name, request.email);
        if (existingStudent != null)
            throw new CustomException("Already exist a student with the same name and email");

        var newId = await _repository.Add(_mapper.Map<Student>(request));

        if (newId == 0)
            throw new CustomException("Student not add. Occurred an error adding student");

        return newId;
    }
}
