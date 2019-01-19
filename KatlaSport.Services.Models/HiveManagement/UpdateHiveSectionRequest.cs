using FluentValidation.Attributes;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a request for creating and updating a hive section.
    /// </summary>
    [Validator(typeof(UpdateHiveSectionRequestValidator))]
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Gets or sets a store hive section name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hive section code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a store hive ID.
        /// </summary>
        public int StoreHiveId { get; set; }
    }
}
