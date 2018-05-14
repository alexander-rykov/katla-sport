using System;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive.
    /// </summary>
    public class Hive
    {
        /// <summary>
        /// Gets or sets a hive identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a hive name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a hive code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a hive is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a store hive address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the hive was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
