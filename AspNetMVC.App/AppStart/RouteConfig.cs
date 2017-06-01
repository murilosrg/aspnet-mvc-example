using System.Web.Routing;
using System.Web.Mvc;

namespace AspNetMVC.App.AppStart
{
    public static class RouteConfig
    {
        public static void MapView(this RouteCollection routes, string path, string template)
        {
            routes.MapRoute(path, path, new
            {
                controller = "App",
                action = "AppView",
                view = template
            });
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
        }
    }
}