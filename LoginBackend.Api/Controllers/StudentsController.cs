using LoginBackend.Application.Interfaces;
using LoginBackend.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudentsController : Controller
{
    private readonly IAddStudentUseCase _addUseCase;

    public StudentsController(IAddStudentUseCase addUseCase)
    {
        _addUseCase = addUseCase;
    }

    [HttpPost]
    public async Task<int> Add([FromBody] AddStudentRequest request)
        => await _addUseCase.Handler(request);
}
