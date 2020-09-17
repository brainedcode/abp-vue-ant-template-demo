using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization.Permissions;
using Volo.Saas;

namespace Volo.Saas.Host
{
    public class SaasHostPermissionDefinitionProviderEntityHistoryTuner : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			var service = context.ServiceProvider.GetRequiredService<IAuditingHelper>();

			if (!service.IsEntityHistoryEnabled(typeof(Tenant)))
			{
				context.TryDisablePermission(SaasHostPermissions.Tenants.ViewChangeHistory);
			}

			if (!service.IsEntityHistoryEnabled(typeof(Edition)))
			{
				context.TryDisablePermission(SaasHostPermissions.Editions.ViewChangeHistory);
			}
		}
	}
}
