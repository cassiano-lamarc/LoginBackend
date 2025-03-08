using LoginBackend.Application.Interfaces;
using LoginBackend.Application.UseCases;

namespace LoginBackend.Api.Configuration;

public static class ServiceConfigurations
{
    public static void ConfigureSerices(IServiceCollection services)
    {
        services.AddScoped<IAddStudentUseCase, AddStudentUseCase>();
    }
}
