using Volo.Abp.Modularity;

namespace StudentRegistration;

[DependsOn(
    typeof(StudentRegistrationApplicationModule),
    typeof(StudentRegistrationDomainTestModule)
)]
public class StudentRegistrationApplicationTestModule : AbpModule
{

}
