using LoginBackend.Domain.Entities;

namespace LoginBackend.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetValid(string email, string password);
}
