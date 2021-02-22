using Microsoft.AspNetCore.Http;
using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using System.Threading.Tasks;

namespace Onion.Application.AuthenticationServices.Interfaces
{
    public interface IUserManager
    {
        int GetCurrentUserId(HttpContext httpContext);
        bool SignInSuccessfull(UserViewModel user);

        Task SignIn(HttpContext httpContext, UserViewModel user, bool isPersistent = false);
        Task SignOut(HttpContext httpContext);
    }
}
