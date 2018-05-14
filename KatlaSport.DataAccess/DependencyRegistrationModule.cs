using Autofac;

namespace KatlaSport.DataAccess
{
    /// <summary>
    /// Represents an assembly dependency registration <see cref="Module"/>.
    /// </summary>
    public sealed class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<ProductCatalogue.ProductCatalogueContext>().As<ProductCatalogue.IProductCatalogueContext>().InstancePerRequest();
            builder.RegisterType<ProductStoreHive.ProductStoreHiveContext>().As<ProductStoreHive.IProductStoreHiveContext>().InstancePerRequest();
            builder.RegisterType<ProductStore.ProductStoreContext>().As<ProductStore.IProductStoreContext>().InstancePerRequest();
            builder.RegisterType<CustomerCatalogue.CustomerContext>().As<CustomerCatalogue.ICustomerContext>().InstancePerRequest();
            builder.RegisterType<DebugDatabaseLogger>().As<IDatabaseLogger>();
        }
    }
}
