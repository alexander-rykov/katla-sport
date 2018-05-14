namespace KatlaSport.DataAccess.ProductCatalogue
{
    internal sealed class ProductCatalogueContext : DomainContextBase<ApplicationDbContext>, IProductCatalogueContext
    {
        public ProductCatalogueContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<ProductCategory> Categories => GetDbSet<ProductCategory>();

        public IEntitySet<CatalogueProduct> Products => GetDbSet<CatalogueProduct>();
    }
}
