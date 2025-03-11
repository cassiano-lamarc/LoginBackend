using FluentValidation;
using LoginBackend.Api.Configuration.Validations;
using LoginBackend.Application.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace LoginBackend.Application.Configuration.Validations;

public static class ValidatorConfigurations
{
    public static void ConfigureFluentValidations(IServiceCollection services)
    {
        services.AddScoped<IValidator<AddStudentRequest>, AddStudentValidation>();
        services.AddScoped<IValidator<LoginCredencialsRequest>, LoginCredencialsValidation>();
    }
}
