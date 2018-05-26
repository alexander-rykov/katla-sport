using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductCatalogue
{
    internal sealed class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            ToTable("product_categories");
            HasKey(i => i.Id);
            HasIndex(i => i.Code);
            Property(i => i.Id).HasColumnName("category_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("category_name").HasMaxLength(60).IsRequired();
            Property(i => i.Code).HasColumnName("category_code").HasMaxLength(5).IsRequired();
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.CreatedBy).HasColumnName("created_by_id").IsRequired();
            Property(i => i.Created).HasColumnName("created_utc").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(i => i.LastUpdatedBy).HasColumnName("updated_by_id").IsRequired();
            Property(i => i.LastUpdated).HasColumnName("updated_utc").IsRequired();

            Property(i => i.Description).HasColumnName("category_description").HasMaxLength(300);
        }
    }
}
