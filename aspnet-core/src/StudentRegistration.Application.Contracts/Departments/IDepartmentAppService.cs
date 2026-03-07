using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace StudentRegistration.Departments;

public interface IDepartmentAppService :
    ICrudAppService<
        DepartmentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateDepartmentDto>
{ }