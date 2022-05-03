using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int GetOrganizationIdByUserId(int id)
        {
            var user = _userRepository.GetById(id);

            if(user is null)
            {
                throw new ArgumentException("User not found for given id", nameof(id));
            }

            return user.OrganizationId;
        }

    }
}
