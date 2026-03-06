using StudentRegistration.Samples;
using Xunit;

namespace StudentRegistration.EntityFrameworkCore.Applications;

[Collection(StudentRegistrationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<StudentRegistrationEntityFrameworkCoreTestModule>
{

}
