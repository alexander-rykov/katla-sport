using System;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class ProductCategoryProductListItem
    {
        /// <summary>
        /// Gets or sets a product identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a product code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a date of the last update.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
