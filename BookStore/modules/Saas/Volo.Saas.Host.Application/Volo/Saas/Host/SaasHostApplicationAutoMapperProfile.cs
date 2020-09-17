using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Saas.Host.Dtos;
using Volo.Saas;

namespace Volo.Saas.Host
{
    public class SaasHostApplicationAutoMapperProfile : Profile
	{
		public SaasHostApplicationAutoMapperProfile()
		{
			CreateMap<Tenant, SaasTenantDto>().Ignore(x => x.EditionName);
			CreateMap<Edition, EditionDto>();
		}
	}
}
