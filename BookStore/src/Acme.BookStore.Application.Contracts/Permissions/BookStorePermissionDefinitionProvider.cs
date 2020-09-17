using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookStorePermissions.GroupName);


            //Define your own permissions here. Example: 
            var dashboardGroup = myGroup.AddPermission(BookStorePermissions.Dashboard.Default, L("Permission:Dashboard"));
            dashboardGroup.AddChild(BookStorePermissions.Dashboard.Analysis, L("Permission:Analysis"));
            dashboardGroup.AddChild(BookStorePermissions.Dashboard.Monitor, L("Permission:Monitor"));
            dashboardGroup.AddChild(BookStorePermissions.Dashboard.Workplace, L("Permission:Workplace"));


            var formPageGroup = myGroup.AddPermission(BookStorePermissions.FormPage.Default, L("Permission:FormPage"));
            formPageGroup.AddChild(BookStorePermissions.FormPage.BaseForm, L("Permission:BaseForm"));
            formPageGroup.AddChild(BookStorePermissions.FormPage.StepForm, L("Permission:StepForm"));
            formPageGroup.AddChild(BookStorePermissions.FormPage.AdvancedForm, L("Permission:AdvancedForm"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
