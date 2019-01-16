using FluentValidation.Attributes;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a request for creating and updating a hive.
    /// </summary>
    [Validator(typeof(UpdateHiveRequestValidator))]
    public class UpdateHiveRequest
    {
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
    }
}
