using System.Data.Entity;
using KatlaSport.Services.Identity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KatlaSport.Services.Identity
{
    /// <summary>
    /// Represents a <see cref="DbContext"/> for ASP.NET Identity infrastructure.
    /// </summary>
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationIdentityDbContext"/> class.
        /// </summary>
        public ApplicationIdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationIdentityDbContext, Configuration>());
        }
    }
}
