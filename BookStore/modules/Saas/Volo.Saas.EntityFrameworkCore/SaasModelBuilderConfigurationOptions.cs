using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Saas.EntityFrameworkCore
{
    public class SaasModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
	{
		public SaasModelBuilderConfigurationOptions(string tablePrefix = "", string schema = null)
			: base(tablePrefix, schema)
		{
		}
	}
}
