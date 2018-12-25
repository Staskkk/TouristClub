using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DB_Cource_1_03_Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static Tuple<Stream, string, string> GetExportPdf<T>(List<T> result, HttpServerUtilityBase server, HttpResponseBase response)
        {
            ReportDocument rd = new ReportDocument();
            string name = typeof(T).Name;
            rd.Load(Path.Combine(server.MapPath("~/Reports"), name + "Report.rpt"));
            rd.SetDataSource(result);
            response.Buffer = false;
            response.ClearContent();
            response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return new Tuple<Stream, string, string>(stream, "application/pdf", name + "Report.pdf");
        }
    }
}
