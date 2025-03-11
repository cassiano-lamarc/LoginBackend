using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Responses;
using LoginBackend.Application.Responses.Students;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers.Students;

[ApiController]
[Route("api/Students")]
public class GetByIdStudentsController : Controller
{
    private readonly IGetStudentByIdUseCase _getByIdUseCase;

    public GetByIdStudentsController(IGetStudentByIdUseCase getBydUseCase)
    {
        _getByIdUseCase = getBydUseCase;   
    }

    [HttpGet("{id}")]
    [ProducesResponseType<GetStudentResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<GetStudentResponse> GetById([FromRoute] int id)
        => await _getByIdUseCase.Handler(id);
}
