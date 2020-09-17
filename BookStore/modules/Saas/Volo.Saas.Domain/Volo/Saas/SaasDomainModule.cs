using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Saas.Localization;
using Volo.Saas;

namespace Volo.Saas
{
    [DependsOn(
		typeof(AbpMultiTenancyModule),
		typeof(SaasDomainSharedModule),
		typeof(AbpDataModule),
		typeof(AbpDddDomainModule),
		typeof(AbpAutoMapperModule),
		typeof(AbpFeatureManagementDomainModule)
	)]
	public class SaasDomainModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<FeatureManagementOptions>(options =>
			{
				options.ProviderPolicies["T"] = "Saas.Tenants.ManageFeatures";
				options.ProviderPolicies["E"] = "Saas.Editions.ManageFeatures";
			});

			context.Services.AddAutoMapperObjectMapper<SaasDomainModule>();

			Configure<AbpAutoMapperOptions>(options =>
			{
				options.AddProfile<SaasDomainMappingProfile>(true);
			});

			Configure<AbpVirtualFileSystemOptions>(options =>
			{
				options.FileSets.AddEmbedded<SaasDomainModule>();
			});

			Configure<AbpDistributedEntityEventOptions>(options =>
			{
				options.EtoMappings.Add<Edition, EditionEto>(typeof(SaasDomainModule));
				options.EtoMappings.Add<Tenant, TenantEto>(typeof(SaasDomainModule));
			});

			Configure<AbpLocalizationOptions>(options => 
			{
				options.Resources.Get<SaasResource>().AddVirtualJson("/Volo/Saas/Localization/Domain");
			});

			Configure<AbpExceptionLocalizationOptions>(options => 
			{
				options.MapCodeNamespace("Saas", typeof(SaasResource));
			});
		}

		public override void PostConfigureServices(ServiceConfigurationContext context)
		{
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
				SaasModuleExtensionConsts.ModuleName,
				SaasModuleExtensionConsts.EntityNames.Tenant,
				typeof(Tenant)
			);
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
				SaasModuleExtensionConsts.ModuleName,
				SaasModuleExtensionConsts.EntityNames.Edition,
				typeof(Edition)
			);
		}
	}
}
