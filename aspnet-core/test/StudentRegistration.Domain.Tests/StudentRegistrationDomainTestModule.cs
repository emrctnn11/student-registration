using Volo.Abp.Modularity;

namespace StudentRegistration;

[DependsOn(
    typeof(StudentRegistrationDomainModule),
    typeof(StudentRegistrationTestBaseModule)
)]
public class StudentRegistrationDomainTestModule : AbpModule
{

}
