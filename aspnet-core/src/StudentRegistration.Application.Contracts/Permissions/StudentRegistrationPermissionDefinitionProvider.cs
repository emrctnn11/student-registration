using StudentRegistration.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace StudentRegistration.Permissions;

public class StudentRegistrationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StudentRegistrationPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StudentRegistrationPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StudentRegistrationResource>(name);
    }
}
