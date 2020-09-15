using System;
using System.Collections.Generic;
using System.Text;
using Acme.BookStore.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.Localization;

namespace Acme.BookStore
{
    /* Inherit your application services from this class.
     */
    public abstract class BookStoreAppService : ApplicationService
    {
        protected BookStoreAppService()
        {
            LocalizationResource = typeof(BookStoreResource);
        }

        [HttpGet]
        public object GetTest()
        {
            return new
            {
                D = L("Permission:Dashboard"),

                A = L("Permission:Analysis"),
            };
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
