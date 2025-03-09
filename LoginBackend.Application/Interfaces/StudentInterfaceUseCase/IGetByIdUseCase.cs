using LoginBackend.Application.Responses;

namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IGetStudentByIdUseCase
{
    Task<GetStudentResponse> Handler(int id);
}
