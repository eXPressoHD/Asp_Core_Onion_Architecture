using AutoMapper;
using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto.User;
using Onion.Infrastructure.Data;
using Onion.Infrastructure.Data.ViewModels;
using Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Application.EmailService
{
    public class PasswordResetService
    {
        private readonly IUserRepository _context;
        private readonly IMapper _mapper;

        public PasswordResetService(IUserRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void SendPasswortRecoveryForUser(PasswordResetModel user)
        {            
            //UserViewModel userData = _mapper.Map<UserViewModel>(_context.GetById(user.UserId));

            //_context.Update(userData);


        }
    }
}
