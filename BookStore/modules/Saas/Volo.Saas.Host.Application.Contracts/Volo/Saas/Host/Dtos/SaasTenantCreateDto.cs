using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Volo.Saas.Host.Dtos
{
    public class SaasTenantCreateDto : SaasTenantCreateOrUpdateDtoBase
	{
		[StringLength(256)]
		[Required]
		[EmailAddress]
		public string AdminEmailAddress { get; set; }

		[StringLength(128)]
		[Required]
		[DisableAuditing]
		public string AdminPassword { get; set; }
	}
}
