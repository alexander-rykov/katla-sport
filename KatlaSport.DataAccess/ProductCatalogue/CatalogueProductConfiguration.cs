using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductCatalogue
{
    internal sealed class CatalogueProductConfiguration : EntityTypeConfiguration<CatalogueProduct>
    {
        public CatalogueProductConfiguration()
        {
            ToTable("catalogue_products");
            HasKey(i => i.Id);
            HasIndex(i => i.Code);
            HasRequired(i => i.Category).WithMany(i => i.Products).HasForeignKey(i => i.CategoryId);
            Property(i => i.Id).HasColumnName("product_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("product_name").HasMaxLength(60).IsRequired();
            Property(i => i.Code).HasColumnName("product_code").HasMaxLength(5).IsRequired();
            Property(i => i.CategoryId).HasColumnName("product_category_id");
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.CreatedBy).HasColumnName("created_by_id").IsRequired();
            Property(i => i.Created).HasColumnName("created_utc").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(i => i.LastUpdatedBy).HasColumnName("updated_by_id").IsRequired();
            Property(i => i.LastUpdated).HasColumnName("updated_utc").IsRequired();
            Property(i => i.Description).HasColumnName("product_description").HasMaxLength(300);
            Property(i => i.ManufacturerCode).HasColumnName("product_manufacturer_code").HasMaxLength(10);
            Property(i => i.Price).HasColumnName("product_price").IsOptional();

            // TODO STEP 2 - Add configuration for "Description", "ManufacturerCode" and "Price" properties here.
        }
    }
}
