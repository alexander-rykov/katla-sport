using System;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents product in hive section.
    /// </summary>
    public class HiveSectionProductCategoryItem
    {
        /// <summary>
        /// Gets or sets a product identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a product code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted.
        /// </summary>
        public bool IsDelivered { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether product delivery to hive section requested or not.
        /// </summary>
        public bool IsRequested { get; set; }

        /// <summary>
        /// Gets or sets a date of request.
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Gets or sets a date of delivery.
        /// </summary>
        public DateTime DeliveryDate { get; set; }
    }
}
