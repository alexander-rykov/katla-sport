﻿namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a request for creating and updating a hive section.
    /// </summary>
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Gets or sets a store hive name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hive code.
        /// </summary>
        public string Code { get; set; }
    }
}
