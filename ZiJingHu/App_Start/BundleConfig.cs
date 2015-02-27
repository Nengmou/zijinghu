using System.Web;
using System.Web.Optimization;

namespace ZiJingHu
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js")); //respond for IE 8 and below

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/ZiJingHu.css"));

            //bundles.Add(new StyleBundle("~/content/jqueryui/css").Include(
            //        "~/Content/themes/base/all.css"));

            //add CLEditor
            //bundles.Add(new StyleBundle("~/CLEditor/all").Include(
            //          "~/CLEditor/jquery.min.js",
            //          "~/CLEditor/jquery.cleditor.min.js",
            //          "~/CLEditor/jquery.cleditor.css"));
        }
    }
}
