using FluentValidation;
using LoginBackend.Application.Requests;
using LoginBackend.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LoginBackend.Application.Configuration.Validations;

public class AddStudentValidation : AbstractValidator<AddStudentRequest>
{
    public AddStudentValidation()
    {
        var nameMaxLength = typeof(Student)?.GetProperty("Name")?
            .GetCustomAttribute<MaxLengthAttribute>()?.Length ?? 100;
        var emailMaxLength = typeof(Student)?.GetProperty("Email")?
            .GetCustomAttribute<MaxLengthAttribute>()?.Length ?? 200;
        var phoneMaxLength = typeof(Student)?.GetProperty("Phone")?
            .GetCustomAttribute<MaxLengthAttribute>()?.Length ?? 20;
        
        RuleFor(s => s.name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(s => s.name)
            .MaximumLength(nameMaxLength)
            .WithMessage($"Name maxlength is {nameMaxLength}");
    
        RuleFor(s => s.email)
            .NotEmpty()
            .WithMessage("Email is required");

        RuleFor(s => s.email)
            .MaximumLength(emailMaxLength)
            .WithMessage($"Email maxlength is {emailMaxLength}");

        RuleFor(s => s.email)
            .EmailAddress()
            .WithMessage("Input valid Email");

        RuleFor(s => s.phone)
            .MaximumLength(phoneMaxLength)
            .WithMessage($"Phone maxlenght is {phoneMaxLength}");
    }
}
