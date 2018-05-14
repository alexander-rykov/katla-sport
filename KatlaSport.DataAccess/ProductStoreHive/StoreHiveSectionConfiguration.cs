using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStoreHive
{
    internal sealed class StoreHiveSectionConfiguration : EntityTypeConfiguration<StoreHiveSection>
    {
        public StoreHiveSectionConfiguration()
        {
            ToTable("product_hive_sections");
            HasKey(i => i.Id);
            HasRequired(i => i.StoreHive).WithMany(i => i.Sections).HasForeignKey(i => i.StoreHiveId);
            Property(i => i.Id).HasColumnName("product_hive_section_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("product_hive_section_name").HasMaxLength(60).IsRequired();
            Property(i => i.Code).HasColumnName("product_hive_code").HasMaxLength(5).IsRequired();
            Property(i => i.StoreHiveId).HasColumnName("product_hive_id");
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.CreatedBy).HasColumnName("created_by_id").IsRequired();
            Property(i => i.Created).HasColumnName("created_utc").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(i => i.LastUpdatedBy).HasColumnName("updated_by_id").IsRequired();
            Property(i => i.LastUpdated).HasColumnName("updated_utc").IsRequired();
        }
    }
}
