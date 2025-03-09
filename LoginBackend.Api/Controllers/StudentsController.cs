using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.Requests;
using LoginBackend.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudentsController : Controller
{
    private readonly IAddStudentUseCase _addUseCase;
    private readonly IGetStudentUseCase _getUSeCase;
    private readonly IDeleteStudentUseCase _deleteUseCase;

    public StudentsController(IAddStudentUseCase addUseCase, IGetStudentUseCase getUseCase, IDeleteStudentUseCase deleteUseCase)
    {
        _addUseCase = addUseCase;
        _getUSeCase = getUseCase;
        _deleteUseCase = deleteUseCase;
    }

    [HttpPost]
    public async Task<int> Add([FromBody] AddStudentRequest request)
        => await _addUseCase.Handler(request);

    [HttpGet]
    public async Task<List<GetStudentResponse>> Get()
        => await _getUSeCase.Handler();

    [HttpDelete("{id}")]
    public async Task<bool> Delete([FromRoute] int id)
        => await _deleteUseCase.Handler(id);
}
