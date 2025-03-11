using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers.Students;

[ApiController]
[Route("api/Students")]
public class AddStudentController : Controller
{
    private readonly IAddStudentUseCase _addUseCase;

    public AddStudentController(IAddStudentUseCase addUseCase)
    {
        _addUseCase = addUseCase;
    }

    [HttpPost]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<int> Add([FromBody] AddStudentRequest request)
        => await _addUseCase.Handler(request);
}
