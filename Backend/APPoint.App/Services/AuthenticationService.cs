using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Exceptions;
using APPoint.App.Models;
using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;

        public AuthenticationService(IUserRepository userRepository, ICryptographyService cryptographyService)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
        }

        public User Login(string login, string password)
        {
            var user = _userRepository.GetAll().Where(u => u.Login == login).Include(u => u.UserType).FirstOrDefault();

            if(user is null)
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.UserNotFound };
            }

            if(user.Password != _cryptographyService.Hash(password))
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.IncorrectPassword }; ;
            }

            return user;
        }
    }
}
