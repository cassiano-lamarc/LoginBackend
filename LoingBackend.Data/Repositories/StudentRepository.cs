using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Interfaces.Repositories;
using LoingBackend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoingBackend.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Student student)
    {
        var newStudent = await _context.AddAsync(student);
        await _context.SaveChangesAsync();

        return newStudent?.Entity?.Id ?? 0;
    }
}
