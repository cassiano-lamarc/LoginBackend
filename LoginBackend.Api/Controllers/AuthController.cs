using FluentValidation;
using LoginBackend.Application.Services;
using LoginBackend.Domain.Exceptions;
using LoginBackend.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginBackend.Application.Responses;
using LoginBackend.Application.Requests;

namespace LoginBackend.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<LoginCredencialsRequest> _validator;

    public AuthController(IUserRepository userRepository, IValidator<LoginCredencialsRequest> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType<object>(StatusCodes.Status200OK)]
    [ProducesResponseType<CustomResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginCredencialsRequest loginCredencials)
    {
        var validation = _validator.Validate(loginCredencials);
        if (!validation.IsValid)
            throw new CustomException(validation?.Errors?.FirstOrDefault()?.ToString());

        var user = await _userRepository.GetValid(loginCredencials?.email, loginCredencials?.password);
        if (user != null)
        {
            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }

        throw new CustomException("Incorret Email or Password");
    }
}
