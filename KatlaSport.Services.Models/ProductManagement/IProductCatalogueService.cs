using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product catalogue service.
    /// </summary>
    public interface IProductCatalogueService
    {
        /// <summary>
        /// Gets a list of products.
        /// </summary>
        /// <param name="start">A start.</param>
        /// <param name="amount">An amount.</param>
        /// <returns>A <see cref="Task{List{ProductListItem}}"/>.</returns>
        Task<List<ProductListItem>> GetProductsAsync(int start, int amount);

        /// <summary>
        /// Gets a list of products for specified product category.
        /// </summary>
        /// <param name="productCategoryId">A product category identifier.</param>
        /// <returns>A <see cref="Task{List{ProductCategoryProductListItem}}"/>.</returns>
        Task<List<ProductCategoryProductListItem>> GetCategoryProductsAsync(int productCategoryId);

        /// <summary>
        /// Gets a product with specified identifier.
        /// </summary>
        /// <param name="productId">A product identifier.</param>
        /// <returns>A <see cref="Task{Product}"/>.</returns>
        Task<Product> GetProductAsync(int productId);

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateProductRequest"/>.</param>
        /// <returns>A <see cref="Task{Product}"/>.</returns>
        Task<Product> CreateProductAsync(UpdateProductRequest createRequest);

        /// <summary>
        /// Updates an existed product.
        /// </summary>
        /// <param name="productId">A product identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateProductRequest"/>.</param>
        /// <returns>A <see cref="Task{Product}"/>.</returns>
        Task<Product> UpdateProductAsync(int productId, UpdateProductRequest updateRequest);

        /// <summary>
        /// Deletes an existed product.
        /// </summary>
        /// <param name="productId">A product identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteProductAsync(int productId);

        /// <summary>
        /// Sets deleted status for a product.
        /// </summary>
        /// <param name="productId">A product identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int productId, bool deletedStatus);
    }
}
