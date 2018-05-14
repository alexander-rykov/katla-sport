using System;
using System.Collections.Generic;
using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.DataAccess.ProductStoreHive
{
    /// <summary>
    /// Represents a store hive section.
    /// </summary>
    public class StoreHiveSection
    {
        /// <summary>
        /// Gets or sets a hive section ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a hive section name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a hive section code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a hive is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a creator's identifier.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the hive section was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets an updator's identifier.
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the hive section was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a store hive ID.
        /// </summary>
        public int StoreHiveId { get; set; }

        /// <summary>
        /// Gets or sets a store hive.
        /// </summary>
        public virtual StoreHive StoreHive { get; set; }

        /// <summary>
        /// Gets or sets a collection of items in the section.
        /// </summary>
        public virtual ICollection<StoreItem> Items { get; set; }

        /// <summary>
        /// Gets or sets a collection of product categories supported for the section.
        /// </summary>
        public virtual ICollection<StoreHiveSectionCategory> Categories { get; set; }
    }
}
