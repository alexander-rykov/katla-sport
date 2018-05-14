namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive.
    /// </summary>
    public class HiveListItem
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
        /// Gets or sets a hive section count.
        /// </summary>
        public int HiveSectionCount { get; set; }
    }
}
