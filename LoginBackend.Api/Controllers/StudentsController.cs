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
    private readonly IGetStudentByIdUseCase _getByIdUseCase;
    private readonly IDeleteStudentUseCase _deleteUseCase;    

    public StudentsController(IAddStudentUseCase addUseCase, IGetStudentUseCase getUseCase, IGetStudentByIdUseCase getBydUseCase, IDeleteStudentUseCase deleteUseCase)
    {
        _addUseCase = addUseCase;
        _getUSeCase = getUseCase;
        _getByIdUseCase = getBydUseCase;
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

    [HttpGet("{id}")]
    public async Task<GetStudentResponse> GetById([FromRoute] int id)
        => await _getByIdUseCase.Handler(id);
}
