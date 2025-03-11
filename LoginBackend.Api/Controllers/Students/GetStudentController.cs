using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Responses;
using LoginBackend.Application.Responses.Students;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers.Students;

[ApiController]
[Route("api/Students")]
public class GetStudentController : Controller
{
    private readonly IGetStudentUseCase _getUSeCase;

    public GetStudentController(IGetStudentUseCase getUseCase)
    {
        _getUSeCase = getUseCase;
    }

    [HttpGet]
    [ProducesResponseType<List<GetStudentResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<GetStudentResponse>> Get()
        => await _getUSeCase.Handler();
}
