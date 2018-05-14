namespace KatlaSport.DataAccess.ProductStoreHive
{
    internal sealed class ProductStoreHiveContext : DomainContextBase<ApplicationDbContext>, IProductStoreHiveContext
    {
        public ProductStoreHiveContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<StoreHive> Hives => GetDbSet<StoreHive>();

        public IEntitySet<StoreHiveSection> Sections => GetDbSet<StoreHiveSection>();

        public IEntitySet<StoreHiveSectionCategory> Categories => GetDbSet<StoreHiveSectionCategory>();
    }
}
