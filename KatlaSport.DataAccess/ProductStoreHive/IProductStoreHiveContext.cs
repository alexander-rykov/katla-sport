namespace KatlaSport.DataAccess.ProductStoreHive
{
    /// <summary>
    /// Represents a context for product store hive domain.
    /// </summary>
    public interface IProductStoreHiveContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="StoreHive"/> entities.
        /// </summary>
        IEntitySet<StoreHive> Hives { get; }

        /// <summary>
        /// Gets a set of <see cref="StoreHiveSection"/> entities.
        /// </summary>
        IEntitySet<StoreHiveSection> Sections { get; }

        /// <summary>
        /// Gets a set of <see cref="StoreHiveSectionCategory"/> entities.
        /// </summary>
        IEntitySet<StoreHiveSectionCategory> Categories { get; }
    }
}
