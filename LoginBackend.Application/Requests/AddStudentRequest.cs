namespace LoginBackend.Application.Requests;

public record AddStudentRequest(string nome, string email, DateTime birthDate, string phone);
