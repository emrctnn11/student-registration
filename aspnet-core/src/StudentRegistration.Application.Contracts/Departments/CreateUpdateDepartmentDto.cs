using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Departments;

public class CreateUpdateDepartmentDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public int Quota { get; set; }
}