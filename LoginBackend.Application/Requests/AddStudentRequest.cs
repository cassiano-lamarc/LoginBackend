namespace LoginBackend.Application.Requests;

public record AddStudentRequest(string name, string email, DateTime? birthDate, string? phone);
