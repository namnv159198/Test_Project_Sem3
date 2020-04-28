using System.Web;
using System.Web.Optimization;

namespace Test_Project_IdentityMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-sortable.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-sortable.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));
            // Admin Template
            bundles.Add(new StyleBundle("~/AdminTemplateContent/css").Include(
                "~/AdminTemplateAssets/assets/vendor/bootstrap/css/bootstrap.min.css",
                "~/AdminTemplateAssets/assets/vendor/font-awesome/css/font-awesome.min.css",
                "~/AdminTemplateAssets/assets/vendor/chartist/css/chartist.min.css",
                "~/AdminTemplateAssets/assets/vendor/chartist-plugin-tooltip/chartist-plugin-tooltip.css",
                "~/AdminTemplateAssets/assets/vendor/toastr/toastr.min.css",
                "~/AdminTemplateAssets/assets/css/main.css",
                "~/AdminTemplateAssets/assets/css/color_skins.css"));

            bundles.Add(new ScriptBundle("~/AdminTemplateBundles/jquery").Include(
                "~/AdminTemplateAssets/assets/bundles/libscripts.bundle.js",
                "~/AdminTemplateAssets/assets/bundles/vendorscripts.bundle.js",
                "~/AdminTemplateAssets/assets/vendor/toastr/toastr.js",
                "~/AdminTemplateAssets/assets/bundles/chartist.bundle.js",
                "~/AdminTemplateAssets/assets/bundles/knob.bundle.js",
                "~/AdminTemplateAssets/assets/bundles/mainscripts.bundle.js",
                "~/AdminTemplateAssets/assets/js/index.js"));
        }
    }
}
