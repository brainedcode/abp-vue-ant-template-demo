using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.Saas.Host
{
    [DependsOn(
		typeof(SaasHostApplicationContractsModule),
		typeof(AbpHttpClientModule)
	)]
	public class SaasHostHttpApiClientModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddHttpClientProxies(typeof(SaasHostApplicationContractsModule).Assembly, SaasHostRemoteServiceConsts.RemoteServiceName);
		}
	}
}
