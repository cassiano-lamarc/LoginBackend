using FluentValidation;
using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class EditStudentUseCase : StudentBaseUseCase, IEditStudentUseCase
{
    private readonly IValidator<AddStudentRequest> _validator;

    public EditStudentUseCase(IStudentRepository repository, IValidator<AddStudentRequest> validator) : base(repository)
    {
        _validator = validator;
    }

    public async Task<bool> Handler(int id, AddStudentRequest request)
    {
        var validator = _validator.Validate(request);
        if (!validator.IsValid)
            throw new CustomException(validator?.Errors?.FirstOrDefault()?.ToString());

        var student = (await _repository.Get(id)).FirstOrDefault();
        if (student == null)
            throw new CustomException("Student not found");

        var existingStudent = await _repository.Get(null, request?.name, request?.email);
        if (existingStudent?.Any(x => x.Id != id) ?? false)
            throw new CustomException("Already exist a student with the same name and email");

        student.BirthDate = request.birthDate;
        student.Phone = request.phone;
        student.Email = request.email;
        student.Name = request.name;

        await _repository.Update(student);

        return true;
    }
}
