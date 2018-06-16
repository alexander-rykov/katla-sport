using Microsoft.AspNet.Identity.EntityFramework;

namespace KatlaSport.Services.Identity
{
    /// <summary>
    /// Represents an application role.
    /// </summary>
    public class ApplicationRole : IdentityRole, IApplicationRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        public ApplicationRole()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class with specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">A role name.</param>
        public ApplicationRole(string name)
            : base(name)
        {
        }
    }
}
