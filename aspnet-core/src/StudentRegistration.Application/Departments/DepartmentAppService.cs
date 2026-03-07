using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace StudentRegistration.Departments;

public class DepartmentAppService :
    CrudAppService<
        Department,
        DepartmentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateDepartmentDto>,
    IDepartmentAppService
{
    public DepartmentAppService(IRepository<Department, Guid> repository)
        : base(repository)
    {

    }
}