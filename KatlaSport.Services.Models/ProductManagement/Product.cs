namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product : ProductCategoryProductListItem
    {
        /// <summary>
        /// Gets or sets a parent product category identifier.
        /// </summary>
        public int CategoryId { get; set; }

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
        public decimal Price { get; set; }
    }
}
