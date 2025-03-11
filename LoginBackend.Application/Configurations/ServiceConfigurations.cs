using LoginBackend.Application.Interfaces.StudentInterfaceUseCase;
using LoginBackend.Application.UseCases.StudentUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace LoginBackend.Application.Configuration;

public static class ServiceConfigurations
{
    public static void ConfigureSerices(IServiceCollection services)
    {
        services.AddScoped<IAddStudentUseCase, AddStudentUseCase>();
        services.AddScoped<IGetStudentUseCase, GetStudentUseCase>();
        services.AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>();
        services.AddScoped<IGetStudentByIdUseCase, GetStudentByIdUseCase>();
        services.AddScoped<IEditStudentUseCase, EditStudentUseCase>();
    }
}
