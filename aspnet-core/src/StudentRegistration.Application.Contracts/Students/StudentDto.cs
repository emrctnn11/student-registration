using System;
using Volo.Abp.Application.Dtos;

namespace StudentRegistration.Students;

public class StudentDto : FullAuditedEntityDto<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}