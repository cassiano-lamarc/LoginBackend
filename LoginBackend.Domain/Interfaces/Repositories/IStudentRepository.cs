using LoginBackend.Domain.Entities;

namespace LoginBackend.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<int> Add(Student student);
    Task<List<Student>> Get(int? id = null);
    Task Remove(Student student);
}
