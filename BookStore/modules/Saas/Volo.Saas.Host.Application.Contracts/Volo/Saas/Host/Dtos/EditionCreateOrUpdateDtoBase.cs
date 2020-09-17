using Volo.Abp.ObjectExtending;

namespace Volo.Saas.Host.Dtos
{
    public abstract class EditionCreateOrUpdateDtoBase : ExtensibleObject
	{
		public string DisplayName { get; set; }

		protected EditionCreateOrUpdateDtoBase()
			: base(false)
		{
		}
	}
}
