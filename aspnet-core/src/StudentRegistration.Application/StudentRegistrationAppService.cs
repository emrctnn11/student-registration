using System;
using System.Collections.Generic;
using System.Text;
using StudentRegistration.Localization;
using Volo.Abp.Application.Services;

namespace StudentRegistration;

/* Inherit your application services from this class.
 */
public abstract class StudentRegistrationAppService : ApplicationService
{
    protected StudentRegistrationAppService()
    {
        LocalizationResource = typeof(StudentRegistrationResource);
    }
}
