using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Saas;

namespace Volo.Saas.EntityFrameworkCore
{
    [ConnectionStringName(SaasDbProperties.ConnectionStringName)]
	public interface ISaasDbContext : IInfrastructure<IServiceProvider>, IResettableService, IDbContextPoolable, IDbSetCache, IDbContextDependencies, IDisposable, IEfCoreDbContext
	{
		DbSet<Tenant> Tenants { get; }

		DbSet<Edition> Editions { get; }

		DbSet<TenantConnectionString> TenantConnectionStrings { get; }
	}
}
