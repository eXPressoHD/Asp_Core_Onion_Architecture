using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.AuthenticationServices;
using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Application.EmailService;
using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto;
using Onion.Core.Domain.Dto.PasswortReset;
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
        private readonly IMailService _mailService;
        private readonly IPasswordResetRepository _passwordReset;

        public AccountController(IUserRepository userRepository,
            IMapper mapper, IUserManager userManager, IMailService mailService,
            IPasswordResetRepository passwordReset)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _mailService = mailService;
            _passwordReset = passwordReset;
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

            if (user != null)
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
            if (model.Password != model.ConfirmPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match";
                return RedirectToAction("Register");
            }

            UserViewModel existingUser = _mapper.Map<UserViewModel>(_userRepository.Get().Where(u => u.Email == model.Email).FirstOrDefault());

            if (existingUser != null)
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

        public IActionResult StartPasswordReset(PasswordResetModel inputModel)
        {
            UserViewModel pwr = new UserViewModel()
            {
                Email = inputModel.Email
            };

            PasswordResetService service = new PasswordResetService(_passwordReset, _mapper, _mailService);
            bool successfullySend = service.SendPasswortRecoveryForUser(pwr);

            if (successfullySend)
            {
                TempData["SuccessMessage"] = "Resetlink send to email.";
            }
            else
            {
                TempData["EmailErrorMessage"] = "Resetlink could not be send to email.";
            }

            return RedirectToAction("StartReset");
        }

        public IActionResult ResetPasswordForUser(UserPasswordResetModel user)
        {
            if (user.Password != user.PasswordRepeat)
            {
                TempData["ErrorMessage"] = "Passwords do not match";
                return RedirectToAction("ResetPasswordForUser");
            }

            if (!String.IsNullOrEmpty(user.TokenHash))
            {
                string dateTimeFormat = "yyyyMMddHHmmss";
                DateTime currentDateTime = Convert.ToDateTime(DateTime.Now.ToString(dateTimeFormat));
                var tokenInDbForUser = _mapper.Map<PasswordResetModel>(_passwordReset.Get().Where(r =>
                                                                       r.Email == user.Email
                                                                       && r.TokenHash == user.TokenHash
                                                                       && DateTime.ParseExact(r.ExpirationDate, dateTimeFormat, null) >= currentDateTime
                                                                       && r.TokenUsed == 0));

                if (tokenInDbForUser == null)
                {
                    TempData["ErrorMessage"] = "Link for reset expired";
                    return RedirectToAction("ResetPasswordForUser");
                }

                UserViewModel userVm = _mapper.Map<UserViewModel>(_userRepository.Get().Where(u => u.Email == user.Email));

                if (userVm != null)
                {
                    userVm.Password = user.PasswordRepeat;

                    _userRepository.Update(_mapper.Map<User>(userVm));
                    _userRepository.Save();

                    //Update Token tab
                    tokenInDbForUser.TokenUsed = 1;

                    _passwordReset.Update(_mapper.Map<PasswordReset>(tokenInDbForUser));
                    _passwordReset.Save();

                    TempData["SuccessMessage"] = "Password successfully changed.";
                    return RedirectToAction("SignIn");
                }
            }

            return RedirectToAction("ResetPassword");
        }
    }
}
