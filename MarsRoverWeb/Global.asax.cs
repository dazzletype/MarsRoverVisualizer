using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarsRoverVisualizer
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "GetRoverHistory",
                "GetRoverHistory", 
                new { controller = "Rover", action = "GetRoverHistory" }
            );

            routes.MapRoute(
                "Get Plateau Coordinates",
                "GetPlateauCoordinates",
                new { controller = "Rover", action = "GetPlateauCoordinates" }
            );


            routes.MapRoute(
                "Get Initial Position",
                "GetInitialPosition",
                new { controller = "Rover", action = "GetInitialPosition" }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Rover", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
        }
    }
}