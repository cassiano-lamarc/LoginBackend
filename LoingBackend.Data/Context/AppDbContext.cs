using LoginBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoingBackend.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Student> Students { get; set; }
}
