using System.Web;
using System.Web.Optimization;

namespace Mobit
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            // admin config
            // jQuery
            bundles.Add(new ScriptBundle("~/admin/bundles/jquery").Include(
                        "~/Areas/Admin/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/jqueryval").Include(
                        "~/Areas/Admin/Scripts/jquery.validate*"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/admin/Content/css").Include(
                      "~/Areas/Admin/Content/bootstrap.min.css",
                      "~/Areas/Admin/Content/animate.css",
                      "~/Areas/Admin/Content/style.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/admin/font-awesome/css").Include(
                      "~/Areas/Admin/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));


            // jQueryUI CSS
            bundles.Add(new StyleBundle("~/admin/Scripts/plugins/jquery-ui/jqueryuiStyles").Include(
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery-ui.css"));

            // jQueryUI 
            bundles.Add(new ScriptBundle("~/admin/bundles/jqueryui").Include(
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery-ui.min.js"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/admin/bundles/bootstrap").Include(
                      "~/Areas/Admin/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/admin/bundles/inspinia").Include(
                      "~/Areas/Admin/Scripts/plugins/metisMenu/metisMenu.min.js",
                      "~/Areas/Admin/Scripts/plugins/pace/pace.min.js",
                      "~/Areas/Admin/Scripts/app/inspinia.js"));

            // Inspinia skin config script
            bundles.Add(new ScriptBundle("~/admin/bundles/skinConfig").Include(
                      "~/Areas/Admin/Scripts/app/skin.config.min.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/admin/plugins/slimScroll").Include(
                      "~/Areas/Admin/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            // Peity
            bundles.Add(new ScriptBundle("~/admin/plugins/peity").Include(
                      "~/Areas/Admin/Scripts/plugins/peity/jquery.peity.min.js"));

            // Video responsible
            bundles.Add(new ScriptBundle("~/admin/plugins/videoResponsible").Include(
                      "~/Areas/Admin/Scripts/plugins/video/responsible-video.js"));

            // Lightbox gallery css styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/blueimp/css/").Include(
                      "~/Areas/Admin/Content/plugins/blueimp/css/blueimp-gallery.min.css"));

            // Lightbox gallery
            bundles.Add(new ScriptBundle("~/admin/plugins/lightboxGallery").Include(
                      "~/Areas/Admin/Scripts/plugins/blueimp/jquery.blueimp-gallery.min.js"));

            // Sparkline
            bundles.Add(new ScriptBundle("~/admin/plugins/sparkline").Include(
                      "~/Areas/Admin/Scripts/plugins/sparkline/jquery.sparkline.min.js"));

            // Morriss chart css styles
            bundles.Add(new StyleBundle("~/admin/plugins/morrisStyles").Include(
                      "~/Areas/Admin/Content/plugins/morris/morris-0.4.3.min.css"));

            // Morriss chart
            bundles.Add(new ScriptBundle("~/admin/plugins/morris").Include(
                      "~/Areas/Admin/Scripts/plugins/morris/raphael-2.1.0.min.js",
                      "~/Areas/Admin/Scripts/plugins/morris/morris.js"));

            // Flot chart
            bundles.Add(new ScriptBundle("~/admin/plugins/flot").Include(
                      "~/Areas/Admin/Scripts/plugins/flot/jquery.flot.js",
                      "~/Areas/Admin/Scripts/plugins/flot/jquery.flot.tooltip.min.js",
                      "~/Areas/Admin/Scripts/plugins/flot/jquery.flot.resize.js",
                      "~/Areas/Admin/Scripts/plugins/flot/jquery.flot.pie.js",
                      "~/Areas/Admin/Scripts/plugins/flot/jquery.flot.time.js",
                      "~/Areas/Admin/Scripts/plugins/flot/jquery.flot.spline.js"));

            // Rickshaw chart
            bundles.Add(new ScriptBundle("~/admin/plugins/rickshaw").Include(
                      "~/Areas/Admin/Scripts/plugins/rickshaw/vendor/d3.v3.js",
                      "~/Areas/Admin/Scripts/plugins/rickshaw/rickshaw.min.js"));

            // ChartJS chart
            bundles.Add(new ScriptBundle("~/admin/plugins/chartJs").Include(
                      "~/Areas/Admin/Scripts/plugins/chartjs/Chart.min.js"));

            // iCheck css styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/iCheck/iCheckStyles").Include(
                      "~/Areas/Admin/Content/plugins/iCheck/custom.css"));

            // iCheck
            bundles.Add(new ScriptBundle("~/admin/plugins/iCheck").Include(
                      "~/Areas/Admin/Scripts/plugins/iCheck/icheck.min.js"));

            // dataTables css styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/dataTables/dataTablesStyles").Include(
                      "~/Areas/Admin/Content/plugins/dataTables/datatables.min.css"));

            // dataTables 
            bundles.Add(new ScriptBundle("~/admin/plugins/dataTables").Include(
                      "~/Areas/Admin/Scripts/plugins/dataTables/datatables.min.js",
                      "~/Areas/Admin/Scripts/plugins/dataTables/dataTables.rowReorder.min.js",
                      "~/Areas/Admin/Scripts/plugins/dataTables/dataTables.select.min.js"));

            // jeditable 
            bundles.Add(new ScriptBundle("~/admin/plugins/jeditable").Include(
                      "~/Areas/Admin/Scripts/plugins/jeditable/jquery.jeditable.js"));

            // jqGrid styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/jqGrid/jqGridStyles").Include(
                      "~/Areas/Admin/Content/plugins/jqGrid/ui.jqgrid.css"));

            // jqGrid 
            bundles.Add(new ScriptBundle("~/admin/plugins/jqGrid").Include(
                      "~/Areas/Admin/Scripts/plugins/jqGrid/i18n/grid.locale-en.js",
                      "~/Areas/Admin/Scripts/plugins/jqGrid/jquery.jqGrid.min.js"));

            // codeEditor styles
            bundles.Add(new StyleBundle("~/admin/plugins/codeEditorStyles").Include(
                      "~/Areas/Admin/Content/plugins/codemirror/codemirror.css",
                      "~/Areas/Admin/Content/plugins/codemirror/ambiance.css"));

            // codeEditor 
            bundles.Add(new ScriptBundle("~/admin/plugins/codeEditor").Include(
                      "~/Areas/Admin/Scripts/plugins/codemirror/codemirror.js",
                      "~/Areas/Admin/Scripts/plugins/codemirror/mode/javascript/javascript.js"));

            // codeEditor 
            bundles.Add(new ScriptBundle("~/admin/plugins/nestable").Include(
                      "~/Areas/Admin/Scripts/plugins/nestable/jquery.nestable.js"));


            // fullCalendar styles
            bundles.Add(new StyleBundle("~/admin/plugins/fullCalendarStyles").Include(
                      "~/Areas/Admin/Content/plugins/fullcalendar/fullcalendar.css"));

            // fullCalendar 
            bundles.Add(new ScriptBundle("~/admin/plugins/fullCalendar").Include(
                      "~/Areas/Admin/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Areas/Admin/Scripts/plugins/fullcalendar/fullcalendar.min.js"));

            // vectorMap 
            bundles.Add(new ScriptBundle("~/admin/plugins/vectorMap").Include(
                      "~/Areas/Admin/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/Areas/Admin/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"));

            // ionRange styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/ionRangeSlider/ionRangeStyles").Include(
                      "~/Areas/Admin/Content/plugins/ionRangeSlider/ion.rangeSlider.css",
                      "~/Areas/Admin/Content/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css"));

            // ionRange 
            bundles.Add(new ScriptBundle("~/admin/plugins/ionRange").Include(
                      "~/Areas/Admin/Scripts/plugins/ionRangeSlider/ion.rangeSlider.min.js"));

            // dataPicker styles
            bundles.Add(new StyleBundle("~/admin/plugins/dataPickerStyles").Include(
                      "~/Areas/Admin/Content/plugins/datapicker/datepicker3.css"));

            // dataPicker 
            bundles.Add(new ScriptBundle("~/admin/plugins/dataPicker").Include(
                      "~/Areas/Admin/Scripts/plugins/datapicker/bootstrap-datepicker.js"));

            // nouiSlider styles
            bundles.Add(new StyleBundle("~/admin/plugins/nouiSliderStyles").Include(
                      "~/Areas/Admin/Content/plugins/nouslider/jquery.nouislider.css"));

            // nouiSlider 
            bundles.Add(new ScriptBundle("~/admin/plugins/nouiSlider").Include(
                      "~/Areas/Admin/Scripts/plugins/nouslider/jquery.nouislider.min.js"));

            // jasnyBootstrap styles
            bundles.Add(new StyleBundle("~/admin/plugins/jasnyBootstrapStyles").Include(
                      "~/Areas/Admin/Content/plugins/jasny/jasny-bootstrap.min.css"));

            // jasnyBootstrap 
            bundles.Add(new ScriptBundle("~/admin/plugins/jasnyBootstrap").Include(
                      "~/Areas/Admin/Scripts/plugins/jasny/jasny-bootstrap.min.js"));

            // switchery styles
            bundles.Add(new StyleBundle("~/admin/plugins/switcheryStyles").Include(
                      "~/Areas/Admin/Content/plugins/switchery/switchery.css"));

            // switchery 
            bundles.Add(new ScriptBundle("~/admin/plugins/switchery").Include(
                      "~/Areas/Admin/Scripts/plugins/switchery/switchery.js"));

            // chosen styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/chosen/chosenStyles").Include(
                      "~/Areas/Admin/Content/plugins/chosen/chosen.css"));

            // chosen 
            bundles.Add(new ScriptBundle("~/admin/plugins/chosen").Include(
                      "~/Areas/Admin/Scripts/plugins/chosen/chosen.jquery.js"));

            // knob 
            bundles.Add(new ScriptBundle("~/admin/plugins/knob").Include(
                      "~/Areas/Admin/Scripts/plugins/jsKnob/jquery.knob.js"));

            // wizardSteps styles
            bundles.Add(new StyleBundle("~/admin/plugins/wizardStepsStyles").Include(
                      "~/Areas/Admin/Content/plugins/steps/jquery.steps.css"));

            // wizardSteps 
            bundles.Add(new ScriptBundle("~/admin/plugins/wizardSteps").Include(
                      "~/Areas/Admin/Scripts/plugins/staps/jquery.steps.min.js"));

            // dropZone styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/dropzone/dropZoneStyles").Include(
                      "~/Areas/Admin/Content/plugins/dropzone/basic.css",
                      "~/Areas/Admin/Content/plugins/dropzone/dropzone.css"));

            // dropZone 
            bundles.Add(new ScriptBundle("~/admin/plugins/dropZone").Include(
                      "~/Areas/Admin/Scripts/plugins/dropzone/dropzone.js"));

            // summernote styles
            bundles.Add(new StyleBundle("~/admin/plugins/summernoteStyles").Include(
                      "~/Areas/Admin/Content/plugins/summernote/summernote.css",
                      "~/Areas/Admin/Content/plugins/summernote/summernote-bs3.css"));

            // summernote 
            bundles.Add(new ScriptBundle("~/admin/plugins/summernote").Include(
                      "~/Areas/Admin/Scripts/plugins/summernote/summernote.min.js"));

            // toastr notification 
            bundles.Add(new ScriptBundle("~/admin/plugins/toastr").Include(
                      "~/Areas/Admin/Scripts/plugins/toastr/toastr.min.js"));

            // toastr notification styles
            bundles.Add(new StyleBundle("~/admin/plugins/toastrStyles").Include(
                      "~/Areas/Admin/Content/plugins/toastr/toastr.min.css"));

            // color picker
            bundles.Add(new ScriptBundle("~/admin/plugins/colorpicker").Include(
                      "~/Areas/Admin/Scripts/plugins/colorpicker/bootstrap-colorpicker.min.js"));

            // color picker styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/colorpicker/colorpickerStyles").Include(
                      "~/Areas/Admin/Content/plugins/colorpicker/bootstrap-colorpicker.min.css"));

            // image cropper
            bundles.Add(new ScriptBundle("~/admin/plugins/imagecropper").Include(
                      "~/Areas/Admin/Scripts/plugins/cropper/cropper.min.js"));

            // image cropper styles
            bundles.Add(new StyleBundle("~/admin/plugins/imagecropperStyles").Include(
                      "~/Areas/Admin/Content/plugins/cropper/cropper.min.css"));

            // jsTree
            bundles.Add(new ScriptBundle("~/admin/plugins/jsTree").Include(
                      "~/Areas/Admin/Scripts/plugins/jsTree/jstree.min.js"));

            // jsTree styles
            bundles.Add(new StyleBundle("~/admin/Content/plugins/jsTree").Include(
                      "~/Areas/Admin/Content/plugins/jsTree/style.css"));

            // Diff
            bundles.Add(new ScriptBundle("~/admin/plugins/diff").Include(
                      "~/Areas/Admin/Scripts/plugins/diff_match_patch/javascript/diff_match_patch.js",
                      "~/Areas/Admin/Scripts/plugins/preetyTextDiff/jquery.pretty-text-diff.min.js"));

            // Idle timer
            bundles.Add(new ScriptBundle("~/admin/plugins/idletimer").Include(
                      "~/Areas/Admin/Scripts/plugins/idle-timer/idle-timer.min.js"));

            // Tinycon
            bundles.Add(new ScriptBundle("~/admin/plugins/tinycon").Include(
                      "~/Areas/Admin/Scripts/plugins/tinycon/tinycon.min.js"));

            // Chartist
            bundles.Add(new StyleBundle("~/admin/plugins/chartistStyles").Include(
                      "~/Areas/Admin/Content/plugins/chartist/chartist.min.css"));

            // jsTree styles
            bundles.Add(new ScriptBundle("~/admin/plugins/chartist").Include(
                      "~/Areas/Admin/Scripts/plugins/chartist/chartist.min.js"));

            // Awesome bootstrap checkbox
            bundles.Add(new StyleBundle("~/admin/plugins/awesomeCheckboxStyles").Include(
                      "~/Areas/Admin/Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            // Clockpicker styles
            bundles.Add(new StyleBundle("~/admin/plugins/clockpickerStyles").Include(
                      "~/Areas/Admin/Content/plugins/clockpicker/clockpicker.css"));

            // Clockpicker
            bundles.Add(new ScriptBundle("~/admin/plugins/clockpicker").Include(
                      "~/Areas/Admin/Scripts/plugins/clockpicker/clockpicker.js"));

            // Date range picker Styless
            bundles.Add(new StyleBundle("~/admin/plugins/dateRangeStyles").Include(
                      "~/Areas/Admin/Content/plugins/daterangepicker/daterangepicker-bs3.css"));

            // Date range picker
            bundles.Add(new ScriptBundle("~/admin/plugins/dateRange").Include(
                      // Date range use moment.js same as full calendar plugin 
                      "~/Areas/Admin/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Areas/Admin/Scripts/plugins/daterangepicker/daterangepicker.js"));

            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/admin/plugins/sweetAlertStyles").Include(
                      "~/Areas/Admin/Content/plugins/sweetalert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/admin/plugins/sweetAlert").Include(
                      "~/Areas/Admin/Scripts/plugins/sweetalert/sweetalert.min.js"));

            // Footable Styless
            bundles.Add(new StyleBundle("~/admin/plugins/footableStyles").Include(
                      "~/Areas/Admin/Content/plugins/footable/footable.core.css", new CssRewriteUrlTransform()));

            // Footable alert
            bundles.Add(new ScriptBundle("~/admin/plugins/footable").Include(
                      "~/Areas/Admin/Scripts/plugins/footable/footable.all.min.js"));

            // Select2 Styless
            bundles.Add(new StyleBundle("~/admin/plugins/select2Styles").Include(
                      "~/Areas/Admin/Content/plugins/select2/select2.min.css"));

            // Select2
            bundles.Add(new ScriptBundle("~/admin/plugins/select2").Include(
                      "~/Areas/Admin/Scripts/plugins/select2/select2.full.min.js"));

            // Masonry
            bundles.Add(new ScriptBundle("~/admin/plugins/masonry").Include(
                      "~/Areas/Admin/Scripts/plugins/masonary/masonry.pkgd.min.js"));

            // Slick carousel Styless
            bundles.Add(new StyleBundle("~/admin/plugins/slickStyles").Include(
                      "~/Areas/Admin/Content/plugins/slick/slick.css", new CssRewriteUrlTransform()));

            // Slick carousel theme Styless
            bundles.Add(new StyleBundle("~/admin/plugins/slickThemeStyles").Include(
                      "~/Areas/Admin/Content/plugins/slick/slick-theme.css", new CssRewriteUrlTransform()));

            // Slick carousel
            bundles.Add(new ScriptBundle("~/admin/plugins/slick").Include(
                      "~/Areas/Admin/Scripts/plugins/slick/slick.min.js"));

            // Ladda buttons Styless
            bundles.Add(new StyleBundle("~/admin/plugins/laddaStyles").Include(
                      "~/Areas/Admin/Content/plugins/ladda/ladda-themeless.min.css"));

            // Ladda buttons
            bundles.Add(new ScriptBundle("~/admin/plugins/ladda").Include(
                      "~/Areas/Admin/Scripts/plugins/ladda/spin.min.js",
                      "~/Areas/Admin/Scripts/plugins/ladda/ladda.min.js",
                      "~/Areas/Admin/Scripts/plugins/ladda/ladda.jquery.min.js"));

            // Dotdotdot buttons
            bundles.Add(new ScriptBundle("~/admin/plugins/truncate").Include(
                      "~/Areas/Admin/Scripts/plugins/dotdotdot/jquery.dotdotdot.min.js"));

            // Touch Spin Styless
            bundles.Add(new StyleBundle("~/admin/plugins/touchSpinStyles").Include(
                      "~/Areas/Admin/Content/plugins/touchspin/jquery.bootstrap-touchspin.min.css"));

            // Touch Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/touchSpin").Include(
                      "~/Areas/Admin/Scripts/plugins/touchspin/jquery.bootstrap-touchspin.min.js"));

            // Tour Styless
            bundles.Add(new StyleBundle("~/admin/plugins/tourStyles").Include(
                      "~/Areas/Admin/Content/plugins/bootstrapTour/bootstrap-tour.min.css"));

            // Tour Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/tour").Include(
                      "~/Areas/Admin/Scripts/plugins/bootstrapTour/bootstrap-tour.min.js"));

            // i18next Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/i18next").Include(
                      "~/Areas/Admin/Scripts/plugins/i18next/i18next.min.js"));

            // Clipboard Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/clipboard").Include(
                      "~/Areas/Admin/Scripts/plugins/clipboard/clipboard.min.js"));

            // c3 Styless
            bundles.Add(new StyleBundle("~/admin/plugins/c3Styles").Include(
                      "~/Areas/Admin/Content/plugins/c3/c3.min.css"));

            // c3 Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/c3").Include(
                      "~/Areas/Admin/Scripts/plugins/c3/c3.min.js"));

            // d3 Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/d3").Include(
                      "~/Areas/Admin/Scripts/plugins/d3/d3.min.js"));

            // Markdown Styless
            bundles.Add(new StyleBundle("~/admin/plugins/markdownStyles").Include(
                      "~/Areas/Admin/Content/plugins/bootstrap-markdown/bootstrap-markdown.min.css"));

            // Markdown Spin
            bundles.Add(new ScriptBundle("~/admin/plugins/markdown").Include(
                      "~/Areas/Admin/Scripts/plugins/bootstrap-markdown/bootstrap-markdown.js",
                      "~/Areas/Admin/Scripts/plugins/bootstrap-markdown/markdown.js"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Areas/Admin/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Areas/Admin/Scripts/bootstrap.js",
            //          "~/Areas/Admin/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Areas/Admin/Content/css").Include(
            //          "~/Areas/Admin/Content/bootstrap.css",
            //          "~/Areas/Admin/Content/site.css"));

            //bundle örneklernini tek dosya halinde toplayıp içerisindeki gereksiz satırları (yorum satırları, boşluklar, yeni satırlar, vb. ) siler.
            BundleTable.EnableOptimizations = true;

        }


    }
}
