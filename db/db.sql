/****** SSMS 的 SelectTopNRows 命令的脚本  ******/
SELECT TOP (1000) [Id]
      ,[TenantId]
      ,[Name]
      ,[ProviderName]
      ,[ProviderKey]
  FROM [BookStore3].[dbo].[AbpPermissionGrants]

  select NewId()

  insert into dbo.AbpPermissionGrants(Id,[Name],ProviderName,ProviderKey)
  values 
  (NewId(),'Saas.Tenants','R','admin'),
  (NewId(),'Saas.Tenants.Create','R','admin'),
  (NewId(),'Saas.Tenants.Update','R','admin'),
  (NewId(),'Saas.Tenants.Delete','R','admin'),
  (NewId(),'Saas.Tenants.ManageFeatures','R','admin'),
  (NewId(),'Saas.Tenants.ManageConnectionStrings','R','admin'),
  (NewId(),'Saas.Editions','R','admin'),
  (NewId(),'Saas.Editions.Create','R','admin'),
  (NewId(),'Saas.Editions.Update','R','admin'),
  (NewId(),'Saas.Editions.Delete','R','admin'),
  (NewId(),'Saas.Editions.ManageFeatures','R','admin');


  create table dbo.AbpEditions(
  Id uniqueidentifier,
[TenantId] uniqueidentifier,
[DisplayName] nvarchar(256) not null,
[ExtraProperties] nvarchar(max),
[ConcurrencyStamp] nvarchar(40),
[CreatorId] uniqueidentifier,
[CreationTime] datetime2(7) not null,

[LastModificationTime] datetime2(7) not null,
[LastModifierId] uniqueidentifier,
[IsDeleted] bit not null,
[DeleterId] uniqueidentifier,
[DeletionTime] datetime2(7) not null,
primary key(Id)
  );
   