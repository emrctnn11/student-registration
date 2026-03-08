using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Students;

public class CreateUpdateStudentDto
{
    [Required]
    [StringLength(64)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(64)]
    public string LastName { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string NationalId { get; set; }

    [Required]
    [StringLength(64)]
    public string Province { get; set; }

    [Required]
    [StringLength(64)]
    public string District { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }
}