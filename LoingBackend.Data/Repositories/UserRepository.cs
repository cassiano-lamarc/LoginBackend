using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Interfaces.Repositories;
using LoingBackend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoingBackend.Data.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public async Task<User?> GetValid(string email, string password)
        => await _context.User.Where(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password)).FirstOrDefaultAsync();
}
