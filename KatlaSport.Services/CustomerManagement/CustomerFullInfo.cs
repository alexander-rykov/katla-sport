namespace KatlaSport.Services.CustomerManagement
{
    /// <summary>
    /// Represents a customer full info.
    /// </summary>
    public class CustomerFullInfo : CustomerBriefInfo
    {
        /// <summary>
        /// Gets or sets a customer address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a customer phone.
        /// </summary>
        public string Phone { get; set; }
    }
}
