﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Exceptions;
using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Login(string login, string password)
        {
            var user = _userRepository.GetAll().Where(u => u.Login == login).FirstOrDefault();

            if(user is null)
            {
                throw new AuthenticationException();
            }

            if(user.Password != password)
            {
                throw new AuthenticationException();
            }
        }
    }
}
