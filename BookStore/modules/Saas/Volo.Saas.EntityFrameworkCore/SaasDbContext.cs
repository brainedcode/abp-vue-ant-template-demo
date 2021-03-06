﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Saas;

namespace Volo.Saas.EntityFrameworkCore
{
    [ConnectionStringName(SaasDbProperties.ConnectionStringName)]
	public class SaasDbContext : AbpDbContext<SaasDbContext>, ISaasDbContext, IInfrastructure<IServiceProvider>, IResettableService, IDbContextPoolable, IDbSetCache, IDbContextDependencies, IDisposable, IEfCoreDbContext
	{
		public DbSet<Tenant> Tenants { get; set; }

		public DbSet<Edition> Editions { get; set; }

		public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

		public SaasDbContext(DbContextOptions<SaasDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ConfigureSaas(null);
		}
	}
}
