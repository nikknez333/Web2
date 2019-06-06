using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApp.Models;
using WebApp.Persistence;

namespace WebApp.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            ApplicationUserManager userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);


            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.!!!!");
                return;
            }

            //Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim claim = user.Claims.FirstOrDefault(x => x.UserId == user.Id && x.ClaimType.Equals("Rola"));

            //if (claim == null || claim.ClaimValue != "Administrator")
            //{
            //    context.SetError("Authorization_error", "Only administrators can access this page");
            //    return;
            //}
            
            //if (!user.EmailConfirmed)
            //{
            //    context.SetError("invalid_grant", "AppUser did not confirm email.");
            //    return;
            //}

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");
          
            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }

        //public override async Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        //{

        //    ApplicationUserManager userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
        //    var claims = await userManager.GetClaimsAsync(context.AuthorizeRequest.ClientId);

        //    var claim = claims.FirstOrDefault(x => x.ValueType.Equals("Rola"));

        //    if (claim == null || claim.Value != "Administrator")
        //    {
        //        context.Response.StatusCode = 401;// ("Authorization_error", "Only administrators can access this page");
        //        return;
        //    }

        //    return base.AuthorizeEndpoint(context);
        //}
    }
}