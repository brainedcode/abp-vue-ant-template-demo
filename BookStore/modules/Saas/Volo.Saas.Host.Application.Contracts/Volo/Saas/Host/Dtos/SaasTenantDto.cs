using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Saas.Host.Dtos
{
    public class SaasTenantDto : ExtensibleEntityDto<Guid>
	{
		public string Name { get; set; }

		public Guid? EditionId { get; set; }

		public string EditionName { get; set; }
	}
}
