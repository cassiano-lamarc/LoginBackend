using LoginBackend.Domain.Entities;

namespace LoginBackend.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<int> Add(Student student);
    Task<List<Student>> Get(int? id = null, string? exatlyName = null, string? exatlyEmail = null);
    Task Remove(Student student);
    Task Update(Student student);
}
