using System.Web;
using System.Web.Optimization;

namespace LMS.Web.UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                //.Include("~/Content/site.css")
                .Include("~/css/font-awesome.css")
                .Include("~/css/metisMenu.css")
                .Include("~/css/mocha.css")
                .Include("~/css/morris.css")
                .Include("~/css/timeline.css")
                .Include("~/css/sb-admin-2.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/jquery.fancybox.css")
                .Include("~/Content/jquery.jgrowl.css")
            );

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/coreScripts")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/metisMenu.js")
                .Include("~/Scripts/raphael.js")
                .Include("~/Scripts/morris.js")
                .Include("~/Scripts/mocha.js")
                .Include("~/Scripts/sb-admin-2.js")
                .Include("~/Scripts/jquery.fancybox.pack.js")
                .Include("~/Scripts/jquery.jgrowl.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/angularScripts")
                //.Include("~/js/Core/LMS.EntityBase.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/js/AngularEntities/LMS.AngularBuilder.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/ModuleEntity")
                .Include("~/js/AngularEntities/LMS.Entities.Modules.js"));

            bundles.Add(new ScriptBundle("~/bundles/CourseEntity")
                .Include("~/js/AngularEntities/LMS.Entities.Courses.js"));
        }
    }
}