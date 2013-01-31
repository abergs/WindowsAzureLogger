using System;
using System.Globalization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TableStorageLogger;

namespace WebFront
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End(object sender, EventArgs e)
        {
           
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            var exception = httpContext.Server.GetLastError();

            if (exception != null)
                Logger.Add("WebFront", "Error", exception.ToString());

            httpContext.Server.ClearError();
        }
    }
}