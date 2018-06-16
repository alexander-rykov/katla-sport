using Owin;

namespace KatlaSport.Services.Identity
{
    public static class OwinConfiguration
    {
        public static void Configure(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new ApplicationIdentityDbContext());
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        }
    }
}
