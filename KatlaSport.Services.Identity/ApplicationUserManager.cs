using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KatlaSport.Services.Identity
{
    /// <summary>
    /// Represents an application user manager.
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
        /// </summary>
        /// <param name="store">The IUserStore is responsible for commiting changes via the UpdateAsync/CreateAsync methods.</param>
        /// <param name="context"><see cref="DbContext"/> for ASP.NET Identity infrastructure.</param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store, ApplicationDbContext context)
            : base(store)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

/*
        /// <summary>
        /// Creates an instance of <see cref="ApplicationUserManager"/>.
        /// </summary>
        /// <param name="options">Configuration options for a IdentityFactoryMiddleware.</param>
        /// <param name="context">An instace of <see cref="IOwinContext"/></param>
        /// <returns>An instance of <see cref="ApplicationUserManager"/></returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var dbContext = context.Get<ApplicationDbContext>();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext), dbContext);

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
*/
    }
}
