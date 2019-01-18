using System;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive section.
    /// </summary>
    public class HiveSection : HiveSectionListItem
    {
        /// <summary>
        /// Gets or sets a timestamp when the hive section was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a store hive ID.
        /// </summary>
        public int StoreHiveId { get; set; }
    }
}
