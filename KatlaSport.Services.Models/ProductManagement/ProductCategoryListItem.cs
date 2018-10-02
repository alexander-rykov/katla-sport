using System;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product category.
    /// </summary>
    public class ProductCategoryListItem
    {
        /// <summary>
        /// Gets or sets a product category identifier.
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
        /// Gets or sets a value indicating whether a product category is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a date of the last update.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a count of products in a product category.
        /// </summary>
        public int ProductCount { get; set; }
    }
}
