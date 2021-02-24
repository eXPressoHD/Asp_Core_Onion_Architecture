using AutoMapper;
using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Application.EmailService.Interfaces;
using Onion.Core.Domain.Dto;
using Onion.Core.Domain.Dto.PasswortReset;
using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated;
using System;
using System.Linq;

namespace Onion.Application.EmailService
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IPasswordResetRepository _context;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public PasswordResetService(IPasswordResetRepository context, IMapper mapper, IMailService mailService)
        {
            _context = context;
            _mapper = mapper;
            _mailService = mailService;
        }

        /// <summary>
        /// Executed on "PasswordReset" Click by user xy...
        /// </summary>
        /// <param name="userVm">Userobject</param>
        public bool SendPasswortRecoveryForUser(UserViewModel userVm)
        {
            try
            {

                var pwrModel = new PasswordResetModel()
                {
                    Email = userVm.Email,
                    TokenHash = GetNewHashToken(),
                    ExpirationDate = DateTime.Now.AddDays(1).ToString("yyyyMMddHHmmss"),
                    TokenUsed = 0
                };

                _context.Add(_mapper.Map<PasswordReset>(pwrModel));
                _context.Save();

                //Finally 
                SendMailWithResetLink(userVm.Email, pwrModel.TokenHash);
            }catch(Exception ex)
            {
                return false;
            }

            return true;
        }        

        private string GetNewHashToken()
        {
            return Guid.NewGuid().ToString().Substring(0,8);
        }

        /// <summary>
        /// Send mail to user which holds link like -> www.example.com/passwordReset?username=Karan&token=ZB71yObR
        /// </summary>
        /// <param name="mailAddress"></param>
        private void SendMailWithResetLink(string mailAddress, string token)
        {
            string subject = "Password reset";
            string resetLink = $"https://localhost:44363/Account/ResetPassword?token={token}";
            string body = $"Hi, <br> to reset your password, click the link below. <br> Link: {resetLink}";

            _mailService.SendMail(subject, mailAddress, body);
        }
    }
}
