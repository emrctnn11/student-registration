using System;
using StudentRegistration.Departments;
using Volo.Abp.Domain.Entities.Auditing;

namespace StudentRegistration.Students;

public class Student : FullAuditedAggregateRoot<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NationalId { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

}