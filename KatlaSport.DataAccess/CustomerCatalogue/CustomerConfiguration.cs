using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.CustomerCatalogue
{
    internal sealed class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("customer_records");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("customer_id");
            Property(i => i.Name).HasColumnName("customer_name");
            Property(i => i.Address).HasColumnName("customer_address");
            Property(i => i.Phone).HasColumnName("customer_phone");
        }
    }
}
