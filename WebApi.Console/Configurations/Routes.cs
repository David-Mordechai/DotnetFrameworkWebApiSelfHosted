using System.Web.Http;

namespace WebApi.Console.Configurations;

internal static class Routes
{
    public static void ConfigureRoutes(this HttpConfiguration config)
    {
        config.Routes.MapHttpRoute(
            name: "API Default",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}