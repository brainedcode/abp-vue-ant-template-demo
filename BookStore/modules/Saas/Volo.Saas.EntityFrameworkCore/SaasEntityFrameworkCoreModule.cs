using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Saas;

namespace Volo.Saas.EntityFrameworkCore
{
    [DependsOn(
		typeof(SaasDomainModule),
		typeof(AbpEntityFrameworkCoreModule)
	)]
	public class SaasEntityFrameworkCoreModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddAbpDbContext<SaasDbContext>(options =>
			{
				options.AddRepository<Tenant, EfCoreTenantRepository>();
				options.AddRepository<Edition, EfCoreEditionRepository>();
			});
		}
	}
}
