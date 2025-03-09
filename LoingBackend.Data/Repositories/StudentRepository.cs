using LoginBackend.Domain.Entities;
using LoginBackend.Domain.Interfaces.Repositories;
using LoingBackend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoingBackend.Data.Repositories;

public class StudentRepository : BaseRepository, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context) { }

    public async Task<int> Add(Student student)
    {
        var newStudent = await _context.AddAsync(student);
        await _context.SaveChangesAsync();

        return newStudent?.Entity?.Id ?? 0;
    }

    public async Task<List<Student>> Get(int? id = null, string? exatlyName = null, string? exatlyEmail = null)
        => await _context.Students
        .Where(x => (id == null || x.Id == id) &&
            (exatlyName == null || x.Name.ToLower().Trim() == exatlyName.ToLower().Trim()) &&
            (exatlyEmail == null || (x.Email != null && x.Email.ToLower().Trim() == exatlyEmail.ToLower().Trim()))
        )
        .OrderBy(x => x.Id)
        .ToListAsync();

    public async Task Remove(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }
}
