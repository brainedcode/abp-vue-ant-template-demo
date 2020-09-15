using Acme.BookStore.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore
{
    public class DashboardAppService : BookStoreAppService
    {
        private readonly IStringLocalizer<BookStoreResource> _localizer;

        public DashboardAppService(IStringLocalizer<BookStoreResource> localizer)
        {
            _localizer = localizer;
        }

        public string Foo()
        {
            var str = _localizer["Permission:Dashboard"];

            return str;
        }
    }
}
