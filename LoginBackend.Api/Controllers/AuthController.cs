using LoginBackend.Api.Models;
using LoginBackend.Application.Services;
using LoginBackend.Domain.Exceptions;
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
    public async Task<object> Login([FromBody] LoginCredencials loginCredencials)
    {
        var user = await _userRepository.GetValid(loginCredencials?.email, loginCredencials?.password);
        if (user != null)
        {
            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }

        throw new CustomException("Incorret Email or Password");
    }
}
