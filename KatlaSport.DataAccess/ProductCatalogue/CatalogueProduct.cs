using System;
using System.Collections.Generic;
using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.DataAccess.ProductCatalogue
{
    /// <summary>
    /// Represents a catalogue product.
    /// </summary>
    public class CatalogueProduct
    {
        /// <summary>
        /// Gets or sets a product ID.
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
        /// Gets or sets a product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a product manufacturer code.
        /// </summary>
        public string ManufacturerCode { get; set; }

        /// <summary>
        /// Gets or sets a product price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets an ID for the product category the product belongs to.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a creator's identifier.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the product was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets an updator's identifier.
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the product was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a product category that product belongs to.
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets a collection of items for the product.
        /// </summary>
        public virtual ICollection<StoreItem> Items { get; set; }
    }
}
