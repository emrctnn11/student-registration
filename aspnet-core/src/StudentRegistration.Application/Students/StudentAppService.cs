using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using StudentRegistration.Hubs;

namespace StudentRegistration.Students;

public class StudentAppService :
    CrudAppService<
        Student,
        StudentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateStudentDto>,
    IStudentAppService
{
    private readonly StudentManager _studentManager;
    private readonly IHubContext<StudentHub> _hubContext;

    public StudentAppService(
        IRepository<Student, Guid> repository,
        StudentManager studentManager,
        IHubContext<StudentHub> hubContext)
        : base(repository)
    {
        _studentManager = studentManager;
        _hubContext = hubContext;
    }

    public override async Task<StudentDto> CreateAsync(CreateUpdateStudentDto input)
    {
        await _studentManager.ValidateQuotaAsync(input.DepartmentId);
        var student = await base.CreateAsync(input);
        await _hubContext.Clients.All.SendAsync("StudentChanged", new { Action = "Created", Student = student });
        return student;
    }

    public override async Task<StudentDto> UpdateAsync(Guid id, CreateUpdateStudentDto input)
    {
        await _studentManager.ValidateQuotaAsync(input.DepartmentId);
        var student = await base.UpdateAsync(id, input);
        await _hubContext.Clients.All.SendAsync("StudentChanged", new { Action = "Updated", Student = student });
        return student;
    }

    public override async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
        await _hubContext.Clients.All.SendAsync("StudentChanged", new { Action = "Deleted", Id = id });
    }
}