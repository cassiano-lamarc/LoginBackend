using LoginBackend.Application.Requests;

namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IAddStudentUseCase
{
    Task<int> Handler(AddStudentRequest request);
}
