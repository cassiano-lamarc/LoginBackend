namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IDeleteStudentUseCase
{
    Task<bool> Handler(int id);
}
