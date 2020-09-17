using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Volo.Saas.Host
{
    [DependsOn(
		typeof(SaasDomainModule),
		typeof(SaasHostApplicationContractsModule),
		typeof(AbpAutoMapperModule)
	)]
	public class SaasHostApplicationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddAutoMapperObjectMapper<SaasHostApplicationModule>();
			base.Configure<AbpAutoMapperOptions>(options =>
			{
				options.AddProfile<SaasHostApplicationAutoMapperProfile>(true);
			});
		}
	}
}
