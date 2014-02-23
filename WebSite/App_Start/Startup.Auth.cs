using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace WebSite
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            Grunch.Services.IConfigurationManagerService configurationManager = new Grunch.Services.ConfigurationManagerService();

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            if (!string.IsNullOrEmpty(configurationManager.AppSettings.Get("auth:MicrosoftClientId")) &&
                    !string.IsNullOrEmpty(configurationManager.AppSettings.Get("auth:MicrosoftClientId")))
            {
                app.UseMicrosoftAccountAuthentication(
                    clientId: configurationManager.AppSettings.Get("auth:MicrosoftClientId"),
                    clientSecret: configurationManager.AppSettings.Get("auth:MicrosoftClientId"));
            }

            if (!string.IsNullOrEmpty(configurationManager.AppSettings.Get("auth:TwitterConsumerKey")) &&
                    !string.IsNullOrEmpty(configurationManager.AppSettings.Get("auth:TwitterConsumerSecret")))
            {
                app.UseTwitterAuthentication(
                   consumerKey: configurationManager.AppSettings.Get("auth:TwitterConsumerKey"),
                   consumerSecret: configurationManager.AppSettings.Get("auth:TwitterConsumerSecret"));
            }

            if (!string.IsNullOrEmpty(configurationManager.AppSettings.Get("auth:FacebookAppId")) &&
                    !string.IsNullOrEmpty(configurationManager.AppSettings.Get("auth:FacebookAppSecret")))
            {
                app.UseFacebookAuthentication(
                   appId: configurationManager.AppSettings.Get("auth:FacebookAppId"),
                   appSecret: configurationManager.AppSettings.Get("auth:FacebookAppSecret"));
            }

            app.UseGoogleAuthentication();
        }
    }
}