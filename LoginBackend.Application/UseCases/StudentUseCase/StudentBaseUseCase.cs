using LoginBackend.Domain.Interfaces.Repositories;

namespace LoginBackend.Application.UseCases.StudentUseCase;

public abstract class StudentBaseUseCase
{
    protected readonly IStudentRepository _repository;

    protected StudentBaseUseCase(IStudentRepository repository)
    {
        _repository = repository;
    }
}
