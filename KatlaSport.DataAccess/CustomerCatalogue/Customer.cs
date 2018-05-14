namespace KatlaSport.DataAccess.CustomerCatalogue
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets a customer ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a customer name.
        /// </summary>
        public string Name { get; set; }

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
