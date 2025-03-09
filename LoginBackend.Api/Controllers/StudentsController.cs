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
    private readonly IEditStudentUseCase _editUseCase;
    private readonly IDeleteStudentUseCase _deleteUseCase;
    private readonly IGetStudentByIdUseCase _getByIdUseCase;

    public StudentsController(
        IAddStudentUseCase addUseCase,
        IGetStudentUseCase getUseCase,
        IEditStudentUseCase editUseCase,
        IDeleteStudentUseCase deleteUseCase,
        IGetStudentByIdUseCase getBydUseCase)
    {
        _addUseCase = addUseCase;
        _getUSeCase = getUseCase;
        _editUseCase = editUseCase;
        _deleteUseCase = deleteUseCase;
        _getByIdUseCase = getBydUseCase;
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

    [HttpGet("{id}")]
    public async Task<GetStudentResponse> GetById([FromRoute] int id)
        => await _getByIdUseCase.Handler(id);

    [HttpPut("{id}")]
    public async Task<bool> Edit([FromRoute] int id, [FromBody] AddStudentRequest request)
        => await _editUseCase.Handler(id, request);
}
