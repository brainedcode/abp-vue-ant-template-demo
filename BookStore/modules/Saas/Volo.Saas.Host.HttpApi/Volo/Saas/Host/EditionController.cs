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
    [RemoteService(true, Name = "SaasHost")]
	[Controller]
	[Area("saas")]
	[Route("/api/saas/editions")]
	[ControllerName("Edition")]
	public class EditionController : AbpController, IReadOnlyAppService<EditionDto, EditionDto, Guid, GetEditionsInput>, ICreateAppService<EditionDto, EditionCreateDto>, IUpdateAppService<EditionDto, Guid, EditionUpdateDto>, IDeleteAppService<Guid>, ICreateUpdateAppService<EditionDto, Guid, EditionCreateDto, EditionUpdateDto>, ICrudAppService<EditionDto, EditionDto, Guid, GetEditionsInput, EditionCreateDto, EditionUpdateDto>, ICrudAppService<EditionDto, Guid, GetEditionsInput, EditionCreateDto, EditionUpdateDto>, IEditionAppService, IRemoteService, IApplicationService
	{
		protected IEditionAppService Service { get; }

		public EditionController(IEditionAppService service)
		{
			this.Service = service;
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<EditionDto> GetAsync(Guid id)
		{
			return this.Service.GetAsync(id);
		}

		[HttpGet]
		public virtual Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
		{
			return this.Service.GetListAsync(input);
		}

		[HttpPost]
		public virtual Task<EditionDto> CreateAsync(EditionCreateDto input)
		{
			return this.Service.CreateAsync(input);
		}

		[HttpPut]
		[Route("{id}")]
		public virtual Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
		{
			return this.Service.UpdateAsync(id, input);
		}

		[Route("{id}")]
		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.Service.DeleteAsync(id);
		}

		[HttpGet]
		[Route("statistics/usage-statistic")]
		public virtual Task<GetEditionUsageStatisticsResult> GetUsageStatistics()
		{
			return this.Service.GetUsageStatistics();
		}
	}
}
