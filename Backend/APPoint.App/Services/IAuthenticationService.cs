using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IAuthenticationService
    {
        public User Login(string login, string password);
        public Task<User> Register(User user);
        public Task ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
