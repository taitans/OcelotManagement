using Taitans.OcelotManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Taitans.OcelotManagement.Authorization
{
    public class OcelotPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var ocelotGroup = context.AddGroup(OcelotManagementPermissions.GroupName, L("Permission:OcelotManagement"), Volo.Abp.MultiTenancy.MultiTenancySides.Host);

            var ocelotssPermission = ocelotGroup.AddPermission(OcelotManagementPermissions.Ocelots.Default, L("Permission:OcelotManagement"), Volo.Abp.MultiTenancy.MultiTenancySides.Host);
            ocelotssPermission.AddChild(OcelotManagementPermissions.Ocelots.Create, L("Permission:Create"), Volo.Abp.MultiTenancy.MultiTenancySides.Host);
            ocelotssPermission.AddChild(OcelotManagementPermissions.Ocelots.Update, L("Permission:Edit"), Volo.Abp.MultiTenancy.MultiTenancySides.Host);
            ocelotssPermission.AddChild(OcelotManagementPermissions.Ocelots.Delete, L("Permission:Delete"), Volo.Abp.MultiTenancy.MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<OcelotManagementResource>(name);
        }
    }
}