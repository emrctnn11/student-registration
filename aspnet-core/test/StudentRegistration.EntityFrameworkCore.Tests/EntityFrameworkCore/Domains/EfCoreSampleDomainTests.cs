using StudentRegistration.Samples;
using Xunit;

namespace StudentRegistration.EntityFrameworkCore.Domains;

[Collection(StudentRegistrationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<StudentRegistrationEntityFrameworkCoreTestModule>
{

}
