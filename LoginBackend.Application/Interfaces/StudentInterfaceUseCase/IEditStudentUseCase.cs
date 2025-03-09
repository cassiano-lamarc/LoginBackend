using LoginBackend.Application.Requests;

namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IEditStudentUseCase
{
    Task<bool> Handler(int id, AddStudentRequest request);
}
