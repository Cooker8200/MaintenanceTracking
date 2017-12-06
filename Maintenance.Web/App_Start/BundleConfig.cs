using System.Web;
using System.Web.Optimization;

namespace Maintenance.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/MaintenanceScript.js"));

            //todo -- how to create and use bundles
            bundles.Add(new ScriptBundle("~/bundles/shared").Include(
                        "~/Scripts/Shared.js"));

            bundles.Add(new ScriptBundle("~/bundles/Edit").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/MaintenanceEdit.js",
                        "~/Scripts/EditStepTwo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/MainPageButton.css",
                      "~/Content/MaintenanceStyles.css"));
        }
    }
}
