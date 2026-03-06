using StudentRegistration.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace StudentRegistration.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StudentRegistrationEntityFrameworkCoreModule),
    typeof(StudentRegistrationApplicationContractsModule)
    )]
public class StudentRegistrationDbMigratorModule : AbpModule
{
}
