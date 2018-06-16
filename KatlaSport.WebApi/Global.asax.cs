using FluentValidation.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace KatlaSport.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(DependencyConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Configure();
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);

            ConfigureJsonFormatter(GlobalConfiguration.Configuration);
        }

        private void ConfigureJsonFormatter(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}
