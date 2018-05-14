using KatlaSport.DataAccess.ProductCatalogue;

namespace KatlaSport.DataAccess.ProductStoreHive
{
    /// <summary>
    /// Represents a hive section category.
    /// </summary>
    public class StoreHiveSectionCategory
    {
        /// <summary>
        /// Gets or sets an ID of product category.
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets an ID of store hive section.
        /// </summary>
        public int StoreHiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a product category for the store hive section.
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets a store hive section for product category.
        /// </summary>
        public virtual StoreHiveSection Section { get; set; }
    }
}
