using System.Web.Mvc;
using System.Web.Routing;

namespace WebFront
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "", new { controller = "LogViewer", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}