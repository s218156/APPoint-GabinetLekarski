using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IUserService
    {
        Task<User> AddAsync(User user);
        int GetOrganizationIdByUserId(int id);
        IEnumerable<User> GetDoctorsByOrganizationId(int id);
        User GetById(int id);
        Task StoreRefreshToken(int id, string refreshToken);
    }
}
