using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStoreHive
{
    internal sealed class StoreHiveConfiguration : EntityTypeConfiguration<StoreHive>
    {
        public StoreHiveConfiguration()
        {
            ToTable("product_hives");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("product_hive_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("product_hive_name").HasMaxLength(60).IsRequired();
            Property(i => i.Code).HasColumnName("product_hive_code").HasMaxLength(5).IsRequired();
            Property(i => i.Address).HasColumnName("product_hive_address").HasMaxLength(300).IsRequired();
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.CreatedBy).HasColumnName("created_by_id").IsRequired();
            Property(i => i.Created).HasColumnName("created_utc").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(i => i.LastUpdatedBy).HasColumnName("updated_by_id").IsRequired();
            Property(i => i.LastUpdated).HasColumnName("updated_utc").IsRequired();
        }
    }
}
