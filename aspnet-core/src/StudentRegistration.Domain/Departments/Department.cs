using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace StudentRegistration.Departments;

public class Department : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public int Quota { get; set; }
}