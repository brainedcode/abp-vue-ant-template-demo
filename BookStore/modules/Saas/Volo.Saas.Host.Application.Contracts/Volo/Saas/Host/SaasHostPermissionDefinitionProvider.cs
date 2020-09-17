using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Saas.Localization;

namespace Volo.Saas.Host
{
	public class SaasHostPermissionDefinitionProvider : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			var saasHostGroup = context.AddGroup(SaasHostPermissions.GroupName, L("Permission:Saas"), MultiTenancySides.Host);
			var tenantManagement = saasHostGroup.AddPermission(SaasHostPermissions.Tenants.Default, L("Permission:TenantManagement"), MultiTenancySides.Host);
			tenantManagement.AddChild(SaasHostPermissions.Tenants.Create, L("Permission:Create"), MultiTenancySides.Host);
			tenantManagement.AddChild(SaasHostPermissions.Tenants.Update, L("Permission:Edit"), MultiTenancySides.Host);
			tenantManagement.AddChild(SaasHostPermissions.Tenants.Delete, L("Permission:Delete"), MultiTenancySides.Host);
			tenantManagement.AddChild(SaasHostPermissions.Tenants.ManageFeatures, L("Permission:ManageFeatures"), MultiTenancySides.Host);
			tenantManagement.AddChild(SaasHostPermissions.Tenants.ManageConnectionStrings, L("Permission:ManageConnectionStrings"), MultiTenancySides.Host);
			tenantManagement.AddChild(SaasHostPermissions.Tenants.ViewChangeHistory, L("Permission:ViewChangeHistory"), MultiTenancySides.Host);
			var editionManagement = saasHostGroup.AddPermission(SaasHostPermissions.Editions.Default, L("Permission:EditionManagement"), MultiTenancySides.Host);
			editionManagement.AddChild(SaasHostPermissions.Editions.Create, L("Permission:Create"), MultiTenancySides.Host);
			editionManagement.AddChild(SaasHostPermissions.Editions.Update, L("Permission:Edit"), MultiTenancySides.Host);
			editionManagement.AddChild(SaasHostPermissions.Editions.Delete, L("Permission:Delete"), MultiTenancySides.Host);
			editionManagement.AddChild(SaasHostPermissions.Editions.ManageFeatures, L("Permission:ManageFeatures"), MultiTenancySides.Host);
			editionManagement.AddChild(SaasHostPermissions.Editions.ViewChangeHistory, L("Permission:ViewChangeHistory"), MultiTenancySides.Host);
		}

		private static LocalizableString L(string name)
		{
			return LocalizableString.Create<SaasResource>(name);
		}
	}
}
