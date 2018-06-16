using System;
using KatlaSport.Services.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace KatlaSport.WebApi
{
    /// <summary>
    /// Main configuration entry point.
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OwinConfiguration.Configure(app);

            // Configure the application for OAuth based flow
            OAuthAuthorizationServerOptions oauthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oauthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
