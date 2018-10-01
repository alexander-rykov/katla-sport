using System;
using System.Collections.Generic;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.DataAccess.ProductCatalogue
{
    /// <summary>
    /// Represents a product catalogue category.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Gets or sets a product category ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a product category code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a product category description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product category is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a creator's identifier.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the product category was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets an updator's identifier.
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the product category was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a collection of products for the product category.
        /// </summary>
        public virtual ICollection<CatalogueProduct> Products { get; set; }

        /// <summary>
        /// Gets or sets a collection of hive sections for the product category.
        /// </summary>
        public virtual ICollection<StoreHiveSectionCategory> Sections { get; set; }
    }
}
