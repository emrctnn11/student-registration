using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentRegistration.Data;
using Volo.Abp.DependencyInjection;

namespace StudentRegistration.EntityFrameworkCore;

public class EntityFrameworkCoreStudentRegistrationDbSchemaMigrator
    : IStudentRegistrationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreStudentRegistrationDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the StudentRegistrationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StudentRegistrationDbContext>()
            .Database
            .MigrateAsync();
    }
}
