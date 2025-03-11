using LoginBackend.Application.Responses.Students;

namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IGetStudentUseCase
{
    Task<List<GetStudentResponse>> Handler();
}
