using Microsoft.Extensions.Localization;
using StudentRegistration.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace StudentRegistration;

[Dependency(ReplaceServices = true)]
public class StudentRegistrationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<StudentRegistrationResource> _localizer;

    public StudentRegistrationBrandingProvider(IStringLocalizer<StudentRegistrationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
