using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.AuthenticationServices;
using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Application.EmailService;
using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto.User;
using Onion.Infrastructure.Data.ViewModels;
using Onion.Infrastructure.Data.ViewModels.Authtentication;
using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;        

        public AccountController(IUserRepository userRepository,
            IMapper mapper, IUserManager userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        #region Views

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult StartReset()
        {
            return View();
        }

        #endregion

        public async Task<IActionResult> SignInUser(LoginViewModel model)
        {
            UserViewModel user = _mapper.Map<UserViewModel>(_userRepository.Get()
                .Where(u => u.Email == model.Email && u.Password == model.Password)
                .FirstOrDefault());

            if(user != null)
            {
                await _userManager.SignIn(this.HttpContext, user, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Login failed";
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterViewModel model)
        {
            //ConfirmPWCheck
            if(model.Password != model.ConfirmPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match";
                return RedirectToAction("Register");
            }

            UserViewModel existingUser = _mapper.Map<UserViewModel>(_userRepository.Get().Where(u => u.Email == model.Email).FirstOrDefault());

            if(existingUser != null)
            {
                TempData["ErrorMessage"] = "An account with this email already exists";
                return RedirectToAction("Register");
            }

            var userEntity = new UserViewModel()
            {
                Email = model.Email,
                Password = model.Password
            };

            _userRepository.Add(_mapper.Map<User>(userEntity));
            _userRepository.Save();

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _userManager.SignOut(this.HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public void ResetPasswordForUser(PasswordResetModel model)
        {
            //PasswordResetService service = new PasswordResetService(_userRepository, _mapper);
            //service.SendPasswortRecoveryForUser(model);
        }
    }
}
