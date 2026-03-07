using System.Threading.Tasks;
using StudentRegistration.Departments;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace StudentRegistration.Data;

public class StudentRegistrationDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Department, System.Guid> _departmentRepository;

    public StudentRegistrationDataSeederContributor(IRepository<Department, System.Guid> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _departmentRepository.GetCountAsync() > 0)
            return;

        await _departmentRepository.InsertAsync(new Department { Name = "Computer Engineering", Quota = 25 });
        await _departmentRepository.InsertAsync(new Department { Name = "Electronics Engineering", Quota = 20 });
        await _departmentRepository.InsertAsync(new Department { Name = "Mechanical Engineering", Quota = 45 });
    }
}