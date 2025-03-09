using LoginBackend.Application.Responses;

namespace LoginBackend.Application.Interfaces;

public interface IGetStudentUseCase
{
    Task<List<GetStudentResponse>> Handler();
}
