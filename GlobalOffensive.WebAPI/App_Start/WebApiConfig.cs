using System.Net.Http.Headers;
using System.Web.Http;

namespace GlobalOffensive.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Add our custom TokenValidationHandler to message handler
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Unity
            UnityConfig.RegisterComponents(config);

            // Web API configuration and services
            config.EnableCors();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}