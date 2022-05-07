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
        private readonly ISaltRepository _saltRepository;

        public AuthenticationService(IUserRepository userRepository, ICryptographyService cryptographyService, ISaltRepository saltRepository)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _saltRepository = saltRepository;
        }

        public User Login(string login, string password)
        {
            var user = _userRepository.GetAll().Where(u => u.Login == login).Include(u => u.UserType).FirstOrDefault();

            if(user is null)
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.UserNotFound };
            }

            var salt = _saltRepository.GetByUserId(user.Id);

            if(salt is null)
            {
                throw new AuthenticationException();
            }

            if(user.Password != _cryptographyService.Hash(password, salt.Value))
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.IncorrectPassword }; ;
            }

            return user;
        }
    }
}
