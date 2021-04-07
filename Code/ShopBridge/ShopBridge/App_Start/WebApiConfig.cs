using System.Web.Http;

namespace ShopBridgeWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "HeartBeat", action = "CheckConnection", id = RouteParameter.Optional }
            );
        }
    }
}
