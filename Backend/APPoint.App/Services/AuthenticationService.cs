using System.Transactions;
using APPoint.App.Exceptions;
using APPoint.App.Models;
using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace APPoint.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly ISaltRepository _saltRepository;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(IUserRepository userRepository, ICryptographyService cryptographyService, ISaltRepository saltRepository, ILogger<AuthenticationService> logger)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _saltRepository = saltRepository;
            _logger = logger;
        }

        public async Task ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _userRepository.GetAll().Where(u => u.Id == userId).Include(u => u.UserType).FirstOrDefault();

            if (user is null)
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.UserNotFound };
            }

            var salt = _saltRepository.GetByUserId(user.Id);

            if (salt is null)
            {
                throw new AuthenticationException();
            }

            if (user.Password != _cryptographyService.Hash(oldPassword, salt.Value))
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.IncorrectPassword }; ;
            }

            var newSaltValue = _cryptographyService.GenerateSalt();

            salt.Value = newSaltValue;

            user.Password = _cryptographyService.Hash(newPassword, newSaltValue);

            try
            {
                using var transactionScope = new TransactionScope();

                await _saltRepository.UpdateAsync(salt);

                await _userRepository.UpdateAsync(user);

                transactionScope.Complete();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error occured while changing the password");

                throw;
            }
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

        public async Task<User> Register(User user)
        {
            var salt = new Salt() { Value = _cryptographyService.GenerateSalt() };

            user.Password = _cryptographyService.Hash(user.Password, salt.Value);

            if(_userRepository.GetAll().Any(u => u.Login == user.Login))
            {
                throw new AuthenticationException() { ErrorCode = Constants.ErrorCode.LoginAlreadyTaken };
            }

            User addedUser;
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                addedUser = await _userRepository.AddAsync(user);

                salt.User = addedUser;

                await _saltRepository.AddAsync(salt);

                transactionScope.Complete();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while changing the password");

                throw;
            }

            return addedUser;
        }
    }
}
