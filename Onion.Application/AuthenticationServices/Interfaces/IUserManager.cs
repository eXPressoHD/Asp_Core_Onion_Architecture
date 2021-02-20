using Microsoft.AspNetCore.Http;
using Onion.Core.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.AuthenticationServices.Interfaces
{
    public interface IUserManager
    {
        int GetCurrentUserId(HttpContext httpContext);
        bool SignInSuccessfull(User user);

        Task SignIn(HttpContext httpContext, User user, bool isPersistent = false);
        Task SignOut(HttpContext httpContext);
    }
}
