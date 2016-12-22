using System.Web;
using System.Web.Optimization;

namespace CWC.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/site.css"));
            #endregion
             
            #region CWCCSS_layout
            //----------------------------------------------OUR CSS/CSS----------------------------------------

            bundles.Add(new StyleBundle("~/Content/CWC/css").Include(
                     "~/Content/css/font-awesome-4.7.0/css/font-awesome.css",
                     "~/Content/css/font-awesome-4.7.0/css/font-awesome.min.css",

                     "~/Content/plugins/font-awesome/css/font-awesome.min.css",
                     "~/Content/plugins/simple-line-icons/simple-line-icons.min.css",
                     "~/Content/plugins/bootstrap/css/bootstrap.min.css",
                     "~/Content/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                     "~/Content/plugins/bootstrap-daterangepicker/daterangepicker.min.css",
                     "~/Content/plugins/morris/morris.css",
                     "~/Content/plugins/fullcalendar/fullcalendar.min.css",
                       "~/Content/plugins/ladda/ladda-themeless.min.css",
                     "~/Content/plugins/jqvmap/jqvmap/jqvmap.css",
                     "~/Content/css/globalCSS/components.min.css",
                     "~/Content/css/globalCSS/plugins.min.css",
                     "~/Content/css/layoutCSS/layout.min.css",
                     "~/Content/css/layoutCSS/themes/darkblue.min.css",
                     "~/Content/css/layoutCSS/custom.min.css",
                     "~/Content/css/layoutCSS/datatables.bootstrap.css",
                     "~/Content/css/layoutCSS/datatables.min.css",
                     "~/Content/css/layoutCSS/bootstrap-datepicker3.min.css"


                       ));
             

            bundles.Add(new StyleBundle("~/Content/CWC2/css").Include(
                        "~/Content/plugins/font-awesome/css/font-awesome.min.css",
                        "~/Content/plugins/simple-line-icons/simple-line-icons.min.css",
                        "~/Content/plugins/bootstrap/css/bootstrap.min.css",
                        "~/Content/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                        "~/Content/css/globalCSS/components.min.css",
                        "~/Content/css/globalCSS/plugins.min.css",
                        "~/Content/css/layoutCSS/layout.min.css",
                        "~/Content/css/layoutCSS/themes/darkblue.min.css",
                        "~/Content/css/layoutCSS/custom.min.css",
                        "~/Content/css/contact.min.css"
                  ));



            #endregion CWC


            #region CWCJS_layout
            //----------------------------------------------OUR CSS/JS----------------------------------------

         

            bundles.Add(new ScriptBundle("~/jquery/CWC/js").Include(
                                 "~/Scripts/jquery-1.10.2.min.js"

                                )); 
            bundles.Add(new ScriptBundle("~/Script&Content/CWC/js").Include(
                    "~/Content/plugins/jquery.min.js",
                    "~/Content/ladda.min.js",
                    "~/Content/spin.min.js",
                    "~/Content/ui-buttons.min.js",
                    "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Content/plugins/js.cookie.min.js",
                    "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/Content/plugins/jquery.blockui.min.js",
                    "~/Content/plugins/bootstrap.min.js",
                    "~/Content/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                    "~/Content/plugins/moment.min.js",
                    "~/Content/plugins/raphael-min.js",
                     "~/Content/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                    "~/Content/plugins/morris/morris.min.js",
                    "~/Content/plugins/counterup/jquery.waypoints.min.js",
                    "~/Content/plugins/counterup/jquery.counterup.min.js",
                    "~/Content/plugins/amcharts/amcharts/amcharts.js",
                    "~/Content/plugins/amcharts/amcharts/serial.js",
                    "~/Content/plugins/amcharts/amcharts/pie.js",
                    "~/Content/plugins/amcharts/amcharts/radar.js",
                    "~/Content/plugins/amcharts/amcharts/themes/light.js",
                    "~/Content/plugins/amcharts/amcharts/themes/patterns.js",
                    "~/Content/plugins/amcharts/amcharts/themes/chalk.js",
                    "~/Content/plugins/amcharts/ammap/ammap.js",
                    "~/Content/plugins/amcharts/ammap/maps/js/worldLow.js",
                    "~/Content/plugins/amcharts/amstockcharts/amstock.js",
                    "~/Content/plugins/fullcalendar/fullcalendar.min.js",
                    "~/Content/plugins/horizontal-timeline/horizontal-timeline.js",
                    "~/Content/plugins/flot/jquery.flot.min.js",
                    "~/Content/plugins/flot/jquery.flot.resize.min.js",
                    "~/Content/plugins/flot/jquery.flot.categories.min.js",
                    "~/Content/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                    "~/Content/plugins/jquery.sparkline.min.js",
                    "~/Content/plugins/jqvmap/jqvmap/jquery.vmap.js",
                    "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                    "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                    "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                    "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                    "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                    "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.sampledata.js",
                   "~/Scripts/app.min.js",
                    "~/Scripts/ui-buttons.min.js",
                    "~/Content/plugins/ladda/ladda.min.js",
                    "~/Content/plugins/ladda/spin.min.js",
                    "~/Scripts/pages/dashboard.min.js",
                    "~/Scripts/layoutScripts/layout.min.js",
                    "~/Scripts/layoutScripts/demo.min.js",
                    "~/Scripts/layoutScripts/quick-sidebar.min.js",
                    "~/Scripts/layoutScripts/quick-nav.min.js",
                    "~/Scripts/layoutScripts/table-datatables-buttons.min.js",
                    "~/Scripts/layoutScripts/charts-amcharts.min.js",
                    "~/Scripts/layoutScripts/datatables.bootstrap.js",
                    "~/Scripts/layoutScripts/datatables.min.js",
                    "~/Scripts/layoutScripts/datatable.js",
                    "~/Scripts/layoutScripts/bootstrap-datepicker.min.js"

                    ));
             

            bundles.Add(new ScriptBundle("~/Script&Content/CWC2/js").Include(
                       "~/Content/plugins/jquery.min.js",
                       "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                       "~/Content/plugins/js.cookie.min.js",
                       "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                       "~/Content/plugins/jquery.blockui.min.js",
                       "~/Content/plugins/bootstrap.min.js",
                       "~/Content/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                       "~/Content/plugins/moment.min.js",
                       "~/Content/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                       "~/Content/plugins/morris/morris.min.js",
                       "~/Content/plugins/counterup/jquery.waypoints.min.js",
                       "~/Content/plugins/counterup/jquery.waypoints.min.js",
                       "~/Content/plugins/amcharts/amcharts/amcharts.js",
                       "~/Content/plugins/amcharts/amcharts/serial.js",
                       "~/Content/plugins/amcharts/amcharts/pie.js",
                       "~/Content/plugins/amcharts/amcharts/radar.js",
                       "~/Content/plugins/amcharts/amcharts/themes/light.js",
                       "~/Content/plugins/amcharts/amcharts/themes/patterns.js",
                       "~/Content/plugins/amcharts/amcharts/themes/chalk.js",
                       "~/Content/plugins/amcharts/ammap/ammap.js",
                       "~/Content/plugins/amcharts/ammap/maps/js/worldLow.js",
                       "~/Content/plugins/amcharts/amstockcharts/amstock.js",
                       "~/Content/plugins/fullcalendar/fullcalendar.min.js",
                       "~/Content/plugins/horizontal-timeline/horizontal-timeline.js",
                       "~/Content/plugins/flot/jquery.flot.min.js",
                       "~/Content/plugins/flot/jquery.flot.resize.min.js",
                       "~/Content/plugins/flot/jquery.flot.categories.min.js",
                       "~/Content/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                       "~/Content/plugins/jquery.sparkline.min.js",
                       "~/Content/plugins/jqvmap/jqvmap/jquery.vmap.js",
                       "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                       "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                       "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                       "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                       "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                       "~/Content/plugins/jqvmap/jqvmap/maps/jquery.vmap.sampledata.js",
                       "~/Scripts/app.min.js",
                       "~/Scripts/pages/dashboard.min.js",
                       "~/Scripts/layoutScripts/layout.min.js",
                       "~/Scripts/layoutScripts/demo.min.js",
                       "~/Scripts/layoutScripts/quick-sidebar.min.js",
                       "~/Scripts/layoutScripts/quick-nav.min.js"

                       ));


            bundles.Add(new ScriptBundle("~/Script&Content/CWC3/js").Include(
                     "~/Content/gmaps.min.js",
                     "~/Content/plugins/jquery.min.js",
                     "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                     "~/Content/plugins/js.cookie.min.js",
                     "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                     "~/Content/plugins/jquery.blockui.min.js",
                     "~/Content/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                     "~/Scripts/app.min.js",
                     "~/Scripts/layoutScripts/layout.min.js",
                     "~/Scripts/layoutScripts/demo.min.js",
                     "~/Scripts/layoutScripts/quick-sidebar.min.js",
                     "~/Scripts/layoutScripts/quick-nav.min.js",
                     "~/Content/js/contact.min.js"
                     ));

            #endregion CWCJS_layout
        }
    }
}
