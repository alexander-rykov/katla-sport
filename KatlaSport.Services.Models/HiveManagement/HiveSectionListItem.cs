namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive section.
    /// </summary>
    public class HiveSectionListItem
    {
        /// <summary>
        /// Gets or sets a hive section identifier.
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
    }
}
