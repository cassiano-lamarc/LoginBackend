using System.ComponentModel.DataAnnotations;

namespace LoginBackend.Application.Responses;

public class GetStudentResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
