using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Saas.Host.Dtos;

namespace Volo.Saas.Host
{
    [Controller]
	[Area("saas")]
	[ControllerName("Tenant")]
	[Route("/api/saas/tenants")]
	[RemoteService(true, Name = "SaasHost")]
	public class TenantController : AbpController, IDeleteAppService<Guid>, IRemoteService, IApplicationService, IReadOnlyAppService<SaasTenantDto, SaasTenantDto, Guid, GetTenantsInput>, ICreateAppService<SaasTenantDto, SaasTenantCreateDto>, IUpdateAppService<SaasTenantDto, Guid, SaasTenantUpdateDto>, ICreateUpdateAppService<SaasTenantDto, Guid, SaasTenantCreateDto, SaasTenantUpdateDto>, ICrudAppService<SaasTenantDto, SaasTenantDto, Guid, GetTenantsInput, SaasTenantCreateDto, SaasTenantUpdateDto>, ICrudAppService<SaasTenantDto, Guid, GetTenantsInput, SaasTenantCreateDto, SaasTenantUpdateDto>, ITenantAppService
	{
		protected ITenantAppService Service { get; }

		public TenantController(ITenantAppService service)
		{
			this.Service = service;
		}

		[HttpGet]
		[Route("{id}")]
		public virtual Task<SaasTenantDto> GetAsync(Guid id)
		{
			return this.Service.GetAsync(id);
		}

		[HttpGet]
		public virtual Task<PagedResultDto<SaasTenantDto>> GetListAsync(GetTenantsInput input)
		{
			return this.Service.GetListAsync(input);
		}

		[HttpPost]
		public virtual Task<SaasTenantDto> CreateAsync(SaasTenantCreateDto input)
		{
			this.ValidateModel();
			return this.Service.CreateAsync(input);
		}

		[HttpPut]
		[Route("{id}")]
		public virtual Task<SaasTenantDto> UpdateAsync(Guid id, SaasTenantUpdateDto input)
		{
			return this.Service.UpdateAsync(id, input);
		}

		[HttpDelete]
		[Route("{id}")]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.Service.DeleteAsync(id);
		}

		[Route("{id}/default-connection-string")]
		[HttpGet]
		public virtual Task<string> GetDefaultConnectionStringAsync(Guid id)
		{
			return this.Service.GetDefaultConnectionStringAsync(id);
		}

		[HttpPut]
		[Route("{id}/default-connection-string")]
		public virtual Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
		{
			return this.Service.UpdateDefaultConnectionStringAsync(id, defaultConnectionString);
		}

		[HttpDelete]
		[Route("{id}/default-connection-string")]
		public virtual Task DeleteDefaultConnectionStringAsync(Guid id)
		{
			return this.Service.DeleteDefaultConnectionStringAsync(id);
		}
	}
}
