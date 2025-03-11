using LoginBackend.Application.Responses.Students;

namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IGetStudentByIdUseCase
{
    Task<GetStudentResponse> Handler(int id);
}
