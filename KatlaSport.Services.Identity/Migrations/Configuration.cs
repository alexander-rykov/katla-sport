using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KatlaSport.Services.Identity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationIdentityDbContext>
    {
        public Configuration()
        {
            ContextKey = "ApplicationIdentity";
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = @"Migrations";
            MigrationsNamespace = "KatlaSport.Services.Identity.Migrations";
        }

        protected override void Seed(ApplicationIdentityDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context), context);
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
                RequiredLength = 1
            };

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            var adminRole = new ApplicationRole("administrator");
            var userRole = new ApplicationRole("user");
            var observerRole = new ApplicationRole("observer");

            if (!roleManager.RoleExistsAsync("administrator").Result)
            {
                roleManager.CreateAsync(adminRole).Wait();
                roleManager.CreateAsync(userRole).Wait();
                roleManager.CreateAsync(observerRole).Wait();
            }

            var adminUser = new ApplicationUser
            {
                Email = "admin@katla-sport.com",
                EmailConfirmed = true,
                UserName = "admin@katla-sport.com",
            };

            if (userManager.CreateAsync(adminUser, "katla1").Result == IdentityResult.Success)
            {
                userManager.AddToRoleAsync(adminUser.Id, adminRole.Name).Wait();
            }

            var userUser = new ApplicationUser
            {
                Email = "user@katla-sport.com",
                EmailConfirmed = true,
                UserName = "user@katla-sport.com",
            };

            if (userManager.CreateAsync(userUser, "katla1").Result == IdentityResult.Success)
            {
                userManager.AddToRoleAsync(userUser.Id, userRole.Name).Wait();
            }

            var observerUser = new ApplicationUser
            {
                Email = "observer@katla-sport.com",
                EmailConfirmed = true,
                UserName = "observer@katla-sport.com",
            };

            if (userManager.CreateAsync(observerUser, "katla1").Result == IdentityResult.Success)
            {
                userManager.AddToRoleAsync(observerUser.Id, observerRole.Name).Wait();
            }
        }
    }
}
