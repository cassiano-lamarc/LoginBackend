using FluentValidation;
using LoginBackend.Api.Configuration.Validations;
using LoginBackend.Application.Requests;

namespace LoginBackend.Api.Configuration;

public static class ValidatorConfigurations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IValidator<AddStudentRequest>, AddStudentValidation>();
    }
}
