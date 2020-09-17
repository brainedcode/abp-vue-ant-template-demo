using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Saas.Host.Dtos;

namespace Volo.Saas.Host
{
	public interface IEditionAppService : IDeleteAppService<Guid>, IUpdateAppService<EditionDto, Guid, EditionUpdateDto>, ICreateAppService<EditionDto, EditionCreateDto>, ICreateUpdateAppService<EditionDto, Guid, EditionCreateDto, EditionUpdateDto>, IReadOnlyAppService<EditionDto, EditionDto, Guid, GetEditionsInput>, ICrudAppService<EditionDto, EditionDto, Guid, GetEditionsInput, EditionCreateDto, EditionUpdateDto>, ICrudAppService<EditionDto, Guid, GetEditionsInput, EditionCreateDto, EditionUpdateDto>, IRemoteService, IApplicationService
	{
		Task<GetEditionUsageStatisticsResult> GetUsageStatistics();
	}
}
