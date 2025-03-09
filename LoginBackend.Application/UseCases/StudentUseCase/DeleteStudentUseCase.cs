using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public class DeleteStudentUseCase : StudentBaseUseCase, IDeleteStudentUseCase
{
    public DeleteStudentUseCase(IStudentRepository repository) : base(repository) { }

    public async Task<bool> Handler(int id)
    {
        var student = await _repository.Get(id);
        if (student == null || student.Count == 0)
            throw new CustomException("Student not found");

        await _repository.Remove(student.FirstOrDefault()!);

        return true;
    }
}
