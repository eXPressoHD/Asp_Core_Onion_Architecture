using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.AuthenticationServices
{
    public class UserManager : IUserManager
    {
        private IEnumerable<Claim> GenerateClaimsFromAppUser(UserViewModel user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
            claims.Add(new Claim(AppClaimTypes.UserId, user.UserId.ToString()));

            return claims;
        }

        public bool SignInSuccessfull(UserViewModel user)
        {
            //db check
            throw new NotImplementedException();
        }

        public async Task SignIn(HttpContext httpContext, UserViewModel user, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GenerateClaimsFromAppUser(user),
                CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal,
              new Microsoft.AspNetCore.Authentication.AuthenticationProperties() { IsPersistent = isPersistent }
            );
        }        

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public int GetCurrentUserId(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
                return -1;
            Claim claim = context.User.Claims.FirstOrDefault(c => c.Type == AppClaimTypes.UserId);
            if (claim == null)
                return -1;
            int currentUserId;
            if (!int.TryParse(claim.Value, out currentUserId))
                return -1;

            return currentUserId;
        }
    }
}
