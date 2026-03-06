using Volo.Abp.Modularity;

namespace StudentRegistration;

/* Inherit from this class for your domain layer tests. */
public abstract class StudentRegistrationDomainTestBase<TStartupModule> : StudentRegistrationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
