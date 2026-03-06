using Volo.Abp.Modularity;

namespace StudentRegistration;

public abstract class StudentRegistrationApplicationTestBase<TStartupModule> : StudentRegistrationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
