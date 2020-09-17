using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using Volo.Saas;

namespace Volo.Saas
{
	public interface ITenantManager : ITransientDependency, IDomainService
	{
		Task<Tenant> CreateAsync(string name, Guid? editionId = null);

		Task ChangeNameAsync(Tenant tenant, string name);
	}
}
