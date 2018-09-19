using System.Web.Optimization;

namespace Xm.Trial
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/bundles/js")
                .IncludeDirectory("~/Content/js/", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/bundles/css")
                .Include("~/Content/css/*.css"));
        }
    }
}