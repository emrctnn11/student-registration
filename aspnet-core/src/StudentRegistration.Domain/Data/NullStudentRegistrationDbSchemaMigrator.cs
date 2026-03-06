using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace StudentRegistration.Data;

/* This is used if database provider does't define
 * IStudentRegistrationDbSchemaMigrator implementation.
 */
public class NullStudentRegistrationDbSchemaMigrator : IStudentRegistrationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
