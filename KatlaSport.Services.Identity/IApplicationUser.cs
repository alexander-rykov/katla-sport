namespace KatlaSport.Services.Identity
{
    /// <summary>
    /// Represents an application user.
    /// </summary>
    public interface IApplicationUser
    {
        /// <summary>
        /// Gets a user identifier.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets a user name.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets a user email.
        /// </summary>
        string Email { get; set; }
    }
}
