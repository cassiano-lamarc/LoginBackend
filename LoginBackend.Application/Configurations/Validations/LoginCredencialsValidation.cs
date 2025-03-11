using FluentValidation;
using LoginBackend.Application.Requests;

namespace LoginBackend.Api.Configuration.Validations;

public class LoginCredencialsValidation : AbstractValidator<LoginCredencialsRequest>
{
    public LoginCredencialsValidation()
    {
        RuleFor(x => x.email)
            .NotEmpty()
            .WithMessage("Email is required");

        RuleFor(x => x.email)
            .EmailAddress()
            .WithMessage("Input valid Email");

        RuleFor(x => x.password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}
