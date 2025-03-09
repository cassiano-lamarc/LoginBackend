using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class EditStudentUseCase : StudentBaseUseCase, IEditStudentUseCase
{
    public EditStudentUseCase(IStudentRepository repository) : base(repository)
    {
    }

    public async Task<bool> Handler(int id, AddStudentRequest request)
    {
        var student = (await _repository.Get(id)).FirstOrDefault();
        if (student == null)
            throw new CustomException("Student not found");

        student.BirthDate = request.birthDate;
        student.Phone = request.phone;
        student.Email = request.email;
        student.Name = request.name;

        await _repository.Update(student);

        return true;
    }
}
