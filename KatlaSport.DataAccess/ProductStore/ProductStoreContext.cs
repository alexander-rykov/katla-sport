namespace KatlaSport.DataAccess.ProductStore
{
    internal class ProductStoreContext : DomainContextBase<ApplicationDbContext>, IProductStoreContext
    {
        public ProductStoreContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<StoreItem> Items => GetDbSet<StoreItem>();
    }
}
