using Volo.Abp.Settings;

namespace StudentRegistration.Settings;

public class StudentRegistrationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(StudentRegistrationSettings.MySetting1));
    }
}
