namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class ProductListItem : ProductCategoryProductListItem
    {
        /// <summary>
        /// Gets or sets a parent product category identifier.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets a parent product category code.
        /// </summary>
        public string CategoryCode { get; set; }
    }
}
