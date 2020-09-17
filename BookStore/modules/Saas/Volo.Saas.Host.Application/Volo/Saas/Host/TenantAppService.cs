using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Saas.Host.Dtos;
using Volo.Saas;

namespace Volo.Saas.Host
{
    [Authorize(SaasHostPermissions.Tenants.Default)]
	public class TenantAppService : SaasHostAppServiceBase, IDeleteAppService<Guid>, IRemoteService, IApplicationService, IUpdateAppService<SaasTenantDto, Guid, SaasTenantUpdateDto>, ICreateAppService<SaasTenantDto, SaasTenantCreateDto>, ICreateUpdateAppService<SaasTenantDto, Guid, SaasTenantCreateDto, SaasTenantUpdateDto>, IReadOnlyAppService<SaasTenantDto, SaasTenantDto, Guid, GetTenantsInput>, ICrudAppService<SaasTenantDto, SaasTenantDto, Guid, GetTenantsInput, SaasTenantCreateDto, SaasTenantUpdateDto>, ICrudAppService<SaasTenantDto, Guid, GetTenantsInput, SaasTenantCreateDto, SaasTenantUpdateDto>, ITenantAppService
	{
		protected IEditionRepository EditionRepository { get; }

		protected IDataSeeder DataSeeder { get; }

		protected ITenantRepository TenantRepository { get; }

		protected ITenantManager TenantManager { get; }

		public TenantAppService(ITenantRepository tenantRepository, IEditionRepository editionRepository, ITenantManager tenantManager, IDataSeeder dataSeeder)
		{
			this.EditionRepository = editionRepository;
			this.DataSeeder = dataSeeder;
			this.TenantRepository = tenantRepository;
			this.TenantManager = tenantManager;
		}

		public virtual async Task<SaasTenantDto> GetAsync(Guid id)
		{
			var tenant = await TenantRepository.GetAsync(id);

			return ObjectMapper.Map<Tenant, SaasTenantDto>(tenant);
		}

		public virtual async Task<PagedResultDto<SaasTenantDto>> GetListAsync(GetTenantsInput input)
		{
			var list = await TenantRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount);
			var totalCount = await TenantRepository.GetCountAsync();

			return new PagedResultDto<SaasTenantDto>(
				totalCount,
				ObjectMapper.Map<List<Tenant>, List<SaasTenantDto>>(list)
				);
		}

		[Authorize(SaasHostPermissions.Tenants.Create)]
		public virtual async Task<SaasTenantDto> CreateAsync(SaasTenantCreateDto input)
		{
			var tenant = await TenantManager.CreateAsync(input.Name, input.EditionId);

			return ObjectMapper.Map<Tenant, SaasTenantDto>(tenant);
		}

		[Authorize(SaasHostPermissions.Tenants.Update)]
		public virtual async Task<SaasTenantDto> UpdateAsync(Guid id, SaasTenantUpdateDto input)
		{
			var tenant = await TenantRepository.GetAsync(id);

			if (tenant.Name != input.Name)
				await TenantManager.ChangeNameAsync(tenant, input.Name);

			tenant.EditionId = input.EditionId;

			return ObjectMapper.Map<Tenant, SaasTenantDto>(tenant);
		}

		[Authorize(SaasHostPermissions.Tenants.Delete)]
		public virtual async Task DeleteAsync(Guid id)
		{
			var tenant = await this.TenantRepository.FindAsync(id);
			if (tenant != null)
			{
				await this.TenantRepository.DeleteAsync(tenant);
			}
		}

		[Authorize(SaasHostPermissions.Tenants.ManageConnectionStrings)]
		public virtual async Task<string> GetDefaultConnectionStringAsync(Guid id)
		{
			var tenant = await this.TenantRepository.GetAsync(id);
			return (tenant != null) ? tenant.FindDefaultConnectionString() : null;
		}

		[Authorize(SaasHostPermissions.Tenants.ManageConnectionStrings)]
		public virtual async Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
		{
			var tenant = await this.TenantRepository.GetAsync(id);
			tenant.SetDefaultConnectionString(defaultConnectionString);
			await this.TenantRepository.UpdateAsync(tenant);
		}

		[Authorize(SaasHostPermissions.Tenants.ManageConnectionStrings)]
		public virtual async Task DeleteDefaultConnectionStringAsync(Guid id)
		{
			var tenant = await this.TenantRepository.GetAsync(id);
			tenant.RemoveDefaultConnectionString();
			await this.TenantRepository.UpdateAsync(tenant);
		}
	}
}
