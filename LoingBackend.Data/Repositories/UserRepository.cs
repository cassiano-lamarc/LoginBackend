using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Interfaces.Repositories;
using LoingBackend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoingBackend.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetValid(string email, string password) 
        => await _context.User.Where(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password)).FirstOrDefaultAsync();
}
