using LoginBackend.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly List<string> userNameOrEmailValid = new List<string>
    {
        "cassiano.oliveira",
        "cassiano.oliveira@ambev.com",
        "cassiano.oliveira@nttdata.com"
    };

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(string userNameOrEmail, string password)
    {
        if (userNameOrEmailValid.Contains(userNameOrEmail))
        {
            var token = TokenService.GenerateToken(new Domain.Entities.User() { Guid = new Guid(), Email = userNameOrEmail, UserName = userNameOrEmail });
            return Ok(token);
        }

        return BadRequest("Dados de login inválidos");
    }
}
