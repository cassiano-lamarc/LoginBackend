using LoginBackend.Application.Interfaces;
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

    public StudentsController(IAddStudentUseCase addUseCase, IGetStudentUseCase getUseCase)
    {
        _addUseCase = addUseCase;
        _getUSeCase = getUseCase;
    }

    [HttpPost]
    public async Task<int> Add([FromBody] AddStudentRequest request)
        => await _addUseCase.Handler(request);

    [HttpGet]
    public async Task<List<GetStudentResponse>> Get()
        => await _getUSeCase.Handler();
}
