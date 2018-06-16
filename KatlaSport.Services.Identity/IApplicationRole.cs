namespace KatlaSport.Services.Identity
{
    /// <summary>
    /// Represents an application role.
    /// </summary>
    public interface IApplicationRole
    {
        /// <summary>
        /// Gets a role identifier.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets a role name.
        /// </summary>
        string Name { get; set; }
    }
}
