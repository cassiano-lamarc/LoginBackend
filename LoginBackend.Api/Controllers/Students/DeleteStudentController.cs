using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers.Students;

[ApiController]
[Route("api/Students")]
public class DeleteStudentController : Controller
{
    private readonly IDeleteStudentUseCase _deleteUseCase;

    public DeleteStudentController(
        IDeleteStudentUseCase deleteUseCase)
    {
        _deleteUseCase = deleteUseCase;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesResponseType<CustomResponse>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<bool> Delete([FromRoute] int id)
        => await _deleteUseCase.Handler(id);
}
