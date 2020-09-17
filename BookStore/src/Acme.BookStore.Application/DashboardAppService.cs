using Acme.BookStore.Localization;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(BookStorePermissions.FormPage.BaseForm)]
        [HttpGet]
        public string Foo()
        {
            var str = _localizer["Permission:Dashboard"];

            return str;
        }
    }
}
