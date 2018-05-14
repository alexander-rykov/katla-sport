using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStoreHive
{
    internal sealed class StoreHiveSectionCategoryConfiguration : EntityTypeConfiguration<StoreHiveSectionCategory>
    {
        public StoreHiveSectionCategoryConfiguration()
        {
            ToTable("product_hive_section_categories");
            HasKey(i => new { i.ProductCategoryId, i.StoreHiveSectionId });
            HasRequired(i => i.Category).WithMany(i => i.Sections).HasForeignKey(i => i.ProductCategoryId);
            HasRequired(i => i.Section).WithMany(i => i.Categories).HasForeignKey(i => i.StoreHiveSectionId);
            Property(i => i.ProductCategoryId).HasColumnName("product_category_id");
            Property(i => i.StoreHiveSectionId).HasColumnName("product_hive_section_id");
        }
    }
}
