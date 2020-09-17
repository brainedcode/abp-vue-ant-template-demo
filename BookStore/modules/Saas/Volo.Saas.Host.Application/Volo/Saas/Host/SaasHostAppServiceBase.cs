using Volo.Abp.Application.Services;
using Volo.Saas.Localization;

namespace Volo.Saas.Host
{
    public abstract class SaasHostAppServiceBase : ApplicationService
	{
		protected SaasHostAppServiceBase()
		{
			base.ObjectMapperContext = typeof(SaasHostApplicationModule);
			base.LocalizationResource = typeof(SaasResource);
		}
	}
}
