using LoginBackend.Domain.Interfaces.Repositories;
using LoingBackend.Data.Repositories;

namespace LoginBackend.Api.Configuration;

public static class ServiceConfiguraion
{   
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
