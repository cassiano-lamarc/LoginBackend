using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers.Students;

[ApiController]
[Route("api/Students")]
public class EditStudentController : Controller
{
    private readonly IEditStudentUseCase _editUseCase;

    public EditStudentController(IEditStudentUseCase editUseCase)
    {
        _editUseCase = editUseCase;            
    }

    [HttpPut("{id}")]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<bool> Edit([FromRoute] int id, [FromBody] AddStudentRequest request)
        => await _editUseCase.Handler(id, request);
}
