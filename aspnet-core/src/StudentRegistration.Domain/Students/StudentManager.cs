using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace StudentRegistration.Students;

public class StudentManager : DomainService 
{
    private readonly IRepository<Student, Guid> _studentRepository;
    private readonly IRepository<Departments.Department, Guid> _departmentRepository;

    public StudentManager(
        IRepository<Student, Guid> studentRepository,
        IRepository<Departments.Department, Guid> departmentRepository)
        // Its ABP's generic interface. Giving us GetAsync, Count, Insert etc. To purpose is without writing any SQL. ABP auto creates the implementation for you behind the scene its using EF CORE.
    {
        // Contructor injection.
        _studentRepository = studentRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task ValidateQuotaAsync(Guid departmentId)
    {
        var count = await _studentRepository.CountAsync(s => s.DepartmentId == departmentId);
        var dept = await _departmentRepository.GetAsync(departmentId);
        if (count >= dept.Quota)
            throw new BusinessException("StudentRegistration:QuotaFull")
                .WithData("Department", dept.Name);
    }
}