using LoginBackend.Api.Models;
using LoginBackend.Application.Services;
using LoginBackend.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginBackend.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IUserRepository _userRepository;
    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginCredencials loginCredencials)
    {
        var user = await _userRepository.GetValid(loginCredencials?.email, loginCredencials?.password);
        if (user != null)
        {
            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }

        return BadRequest("Dados de login inválidos");
    }
}
