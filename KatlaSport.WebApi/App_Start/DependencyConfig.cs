using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace KatlaSport.WebApi
{
    public static class DependencyConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Katla")).ToArray());

            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
