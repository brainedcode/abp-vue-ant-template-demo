using Acme.BookStore.Localization;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BookStoreController : AbpController
    {
        protected SignInManager<IdentityUser> SignInManager { get; }
        protected BookStoreController()
        {
            LocalizationResource = typeof(BookStoreResource);
            
        }
    }
}