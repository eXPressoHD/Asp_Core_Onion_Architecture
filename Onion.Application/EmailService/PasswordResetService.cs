using AutoMapper;
using Onion.Application.EmailService.Interfaces;
using Onion.Core.Domain.Dto;
using Onion.Core.Domain.Dto.PasswortReset;
using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated;
using System;

namespace Onion.Application.EmailService
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IPasswordReset _context;
        private readonly IMapper _mapper;

        public PasswordResetService(IPasswordReset context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Executed on "PasswordReset" Click by user xy...
        /// </summary>
        /// <param name="userVm">Userobject</param>
        public void SendPasswortRecoveryForUser(UserViewModel userVm)
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

        }
    }
}
