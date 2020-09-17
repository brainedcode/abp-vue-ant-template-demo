using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Volo.Saas.Tenants
{
	[DependsOn(
		typeof(SaasDomainModule),
		typeof(SaasTenantApplicationContractsModule),
		typeof(AbpAutoMapperModule)
	)]
	public class SaasTenantApplicationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddAutoMapperObjectMapper<SaasTenantApplicationModule>();
			Configure<AbpAutoMapperOptions>(options =>
			{

			});
		}
	}
}
