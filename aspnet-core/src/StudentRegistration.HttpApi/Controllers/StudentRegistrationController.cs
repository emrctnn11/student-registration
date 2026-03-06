using StudentRegistration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace StudentRegistration.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StudentRegistrationController : AbpControllerBase
{
    protected StudentRegistrationController()
    {
        LocalizationResource = typeof(StudentRegistrationResource);
    }
}
