using LoginBackend.Domain.Interfaces.Repositories;
using LoingBackend.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LoginBackend.Application.Configuration;

public static class RepositoryConfiguraions
{   
    public static void ConfigureRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
    }
}
