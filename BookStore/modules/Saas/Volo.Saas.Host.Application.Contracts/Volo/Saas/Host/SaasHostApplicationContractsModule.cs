using System;
using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Saas.Host.Dtos;
using Volo.Saas.Localization;

namespace Volo.Saas.Host
{
    [DependsOn(
		typeof(SaasDomainSharedModule),
		typeof(AbpDddApplicationModule)
	)]
	public class SaasHostApplicationContractsModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpVirtualFileSystemOptions>(options =>
			{
				options.FileSets.AddEmbedded<SaasHostApplicationContractsModule>();
			});

			Configure<AbpLocalizationOptions>(options =>
			{
				options.Resources.Get<SaasResource>().AddVirtualJson("/Volo/Saas/Host/Localization/ApplicationContracts");
			});
		}

		public override void PostConfigureServices(ServiceConfigurationContext context)
		{
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi(
				SaasModuleExtensionConsts.ModuleName,
				SaasModuleExtensionConsts.EntityNames.Tenant,
				new Type[]
				{
					typeof(SaasTenantDto)
				}, 
				new Type[]
				{
					typeof(SaasTenantCreateDto)
				},
				new Type[]
				{
					typeof(SaasTenantUpdateDto)
				});

			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi(
				SaasModuleExtensionConsts.ModuleName, 
				SaasModuleExtensionConsts.EntityNames.Edition, 
				new Type[]
				{
					typeof(EditionDto)
				}, 
				new Type[]
				{
					typeof(EditionCreateDto)
				}, 
				new Type[]
				{
					typeof(EditionUpdateDto)
				});
		}
	}
}
