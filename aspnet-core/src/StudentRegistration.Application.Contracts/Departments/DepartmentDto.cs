using System;
using Volo.Abp.Application.Dtos;

namespace StudentRegistration.Departments;

public class DepartmentDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set;}
    public int Quota { get; set; }
}