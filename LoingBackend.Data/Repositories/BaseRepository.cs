using LoingBackend.Data.Context;

namespace LoingBackend.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}
