using System;
using System.Collections.Generic;

namespace KatlaSport.DataAccess.ProductStoreHive
{
    /// <summary>
    /// Gets or sets a store hive.
    /// </summary>
    public class StoreHive
    {
        /// <summary>
        /// Gets or sets a store hive ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a store hive name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hive code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a store hive address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a hive is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a creator's identifier.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the hive was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets an updator's identifier.
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the hive was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a collection of sections for the store hive.
        /// </summary>
        public virtual ICollection<StoreHiveSection> Sections { get; set; }
    }
}
