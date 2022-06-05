using APPoint.App.Models.Data;
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

        public async Task<User> AddAsync(User user) => await _userRepository.AddAsync(user);

        public User GetById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user is null)
            {
                throw new ArgumentException("User not found for given id", nameof(id));
            }

            return user;
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

        public async Task StoreRefreshToken(int id, string refreshToken)
        {
            var user = _userRepository.GetById(id);

            if (user is null)
            {
                throw new ArgumentException("User not found for given id", nameof(id));
            }

            user.RefreshToken = refreshToken;

            await _userRepository.UpdateAsync(user);
        }
    }
}
