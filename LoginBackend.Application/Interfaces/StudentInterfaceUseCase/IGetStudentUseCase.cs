using LoginBackend.Application.Responses;

namespace LoginBackend.Application.Interfaces.StudentInterfaceUseCase;

public interface IGetStudentUseCase
{
    Task<List<GetStudentResponse>> Handler();
}
