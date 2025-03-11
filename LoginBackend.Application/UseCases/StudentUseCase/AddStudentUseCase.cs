using AutoMapper;
using FluentValidation;
using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class AddStudentUseCase : StudentBaseUseCase, IAddStudentUseCase
{
    private readonly IMapper _mapper;
    private readonly IValidator<AddStudentRequest> _validator;

    public AddStudentUseCase(IMapper mapper, IStudentRepository repository, IValidator<AddStudentRequest> validator) : base(repository)
    {
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<int> Handler(AddStudentRequest request)
    {
        var validator = _validator.Validate(request);
        if (!validator.IsValid)
            throw new CustomException(validator?.Errors?.FirstOrDefault()?.ToString());

        var existingStudent = await _repository.Get(null, request.name, request.email);
        if (existingStudent != null && existingStudent.Count > 0)
            throw new CustomException("Already exist a student with the same name and email");

        var newId = await _repository.Add(_mapper.Map<Student>(request));

        if (newId == 0)
            throw new CustomException("Student not add. Occurred an error adding student");

        return newId;
    }
}
