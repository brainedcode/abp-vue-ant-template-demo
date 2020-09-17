using AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using Volo.Saas;

namespace Volo.Saas
{
    public class SaasDomainMappingProfile : Profile
	{
		public SaasDomainMappingProfile()
		{
			CreateMap<Tenant, TenantConfiguration>()
				.ForMember(ti => ti.ConnectionStrings, opts =>
				{
					opts.MapFrom((tenant, ti) =>
					{
						var connectionStrings = new ConnectionStrings();

						foreach (var tenantConnectionString in tenant.ConnectionStrings)
						{
							connectionStrings[tenantConnectionString.Name] = tenantConnectionString.Value;
						}

						return connectionStrings;
					});
				});

			base.CreateMap<Edition, EditionEto>();
			base.CreateMap<Tenant, TenantEto>();
		}
	}
}
