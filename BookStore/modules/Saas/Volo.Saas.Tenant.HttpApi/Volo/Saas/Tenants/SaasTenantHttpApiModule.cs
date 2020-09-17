using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Saas.Localization;

namespace Volo.Saas.Tenants
{
    [DependsOn(
		typeof(SaasTenantApplicationContractsModule),
		typeof(AbpFeatureManagementHttpApiModule),
		typeof(AbpAspNetCoreMvcModule)
	)]
	public class SaasTenantHttpApiModule : AbpModule
	{
		public override void PreConfigureServices(ServiceConfigurationContext context)
		{
			base.PreConfigure<IMvcBuilder>(mvcBuilder =>
			{
				mvcBuilder.AddApplicationPartIfNotExists(typeof(SaasTenantHttpApiModule).Assembly);
			});
		}

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			base.Configure<AbpLocalizationOptions>(options =>
			{
				options.Resources.Get<SaasResource>().AddBaseTypes(new Type[]
				{
					typeof(AbpUiResource),
					typeof(AbpFeatureManagementResource)
				});
			});
		}
	}
}
