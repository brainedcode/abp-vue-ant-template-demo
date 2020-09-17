namespace Acme.BookStore.Permissions
{
    public static class BookStorePermissions
    {
        public const string GroupName = "BookStore";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static class Dashboard
        {
            public const string Default = GroupName + ".Dashboard";

            public const string Analysis = Default + ".Analysis";
            public const string Monitor = Default + ".Monitor";
            public const string Workplace = Default + ".Workplace";
        }

        public static class FormPage
        {
            public const string Default = GroupName + ".FormPage";
            public const string BaseForm = Default + ".BaseForm";
            public const string StepForm = Default + ".StepForm";
            public const string AdvancedForm = Default + ".AdvancedForm";
        }
    }
}