using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginBackend.Domain.Entities;

public class Student
{
    public Student(int id, string name, string? email, DateTime? birthDate, string? phone)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
        Email = email;
        Phone = phone;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name length is 100 characters")]
    public string Name { get; set; }

    public DateTime? BirthDate { get; set; }

    [MaxLength(200, ErrorMessage = "Email length is 200 charcters")]
    public string? Email { get; set; }

    [MaxLength(20, ErrorMessage = "Phone length is 20 characters")]
    public string? Phone { get; set; }
}
