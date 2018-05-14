namespace KatlaSport.DataAccess.ProductCatalogue
{
    /// <summary>
    /// Represents a context for product catalogue domain.
    /// </summary>
    public interface IProductCatalogueContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="ProductCategory"/> entities.
        /// </summary>
        IEntitySet<ProductCategory> Categories { get; }

        /// <summary>
        /// Gets a set of <see cref="CatalogueProduct"/> entities.
        /// </summary>
        IEntitySet<CatalogueProduct> Products { get; }
    }
}
