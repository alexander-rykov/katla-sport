namespace KatlaSport.DataAccess.CustomerCatalogue
{
    internal sealed class CustomerContext : DomainContextBase<ApplicationDbContext>, ICustomerContext
    {
        public CustomerContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Customer> Customers => GetDbSet<Customer>();
    }
}
