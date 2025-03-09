using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.UseCases.StudentUseCase;

namespace LoginBackend.Api.Configuration;

public static class ServiceConfigurations
{
    public static void ConfigureSerices(IServiceCollection services)
    {
        services.AddScoped<IAddStudentUseCase, AddStudentUseCase>();
        services.AddScoped<IGetStudentUseCase, GetStudentUseCase>();
        services.AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>();
        services.AddScoped<IGetStudentByIdUseCase, GetStudentByIdUseCase>();
    }
}
