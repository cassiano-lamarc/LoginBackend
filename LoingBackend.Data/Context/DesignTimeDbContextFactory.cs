using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LoingBackend.Data.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Defina a string de conexão de forma explícita aqui
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=teacher;Username=docker;Password=docker");

        return new AppDbContext(optionsBuilder.Options);
    }
}
