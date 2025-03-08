using LoginBackend.Application.Requests;

namespace LoginBackend.Application.Interfaces;

public interface IAddStudentUseCase
{
    Task<int> Handler(AddStudentRequest request);
}
