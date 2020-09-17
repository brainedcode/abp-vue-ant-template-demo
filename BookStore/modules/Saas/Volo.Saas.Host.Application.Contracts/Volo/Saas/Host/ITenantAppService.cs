using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Saas.Host.Dtos;

namespace Volo.Saas.Host
{
	public interface ITenantAppService : IDeleteAppService<Guid>, IUpdateAppService<SaasTenantDto, Guid, SaasTenantUpdateDto>, ICreateAppService<SaasTenantDto, SaasTenantCreateDto>, ICreateUpdateAppService<SaasTenantDto, Guid, SaasTenantCreateDto, SaasTenantUpdateDto>, IReadOnlyAppService<SaasTenantDto, SaasTenantDto, Guid, GetTenantsInput>, ICrudAppService<SaasTenantDto, SaasTenantDto, Guid, GetTenantsInput, SaasTenantCreateDto, SaasTenantUpdateDto>, ICrudAppService<SaasTenantDto, Guid, GetTenantsInput, SaasTenantCreateDto, SaasTenantUpdateDto>, IRemoteService, IApplicationService
	{
		Task<string> GetDefaultConnectionStringAsync(Guid id);

		Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString);

		Task DeleteDefaultConnectionStringAsync(Guid id);
	}
}
