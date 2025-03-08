using LoginBackend.Domain.Entities;

namespace LoginBackend.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<int> Add(Student student);
}
