using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IUserService
    {
        int GetOrganizationIdByUserId(int id);
        User GetById(int id);
        Task StoreRefreshToken(int id, string refreshToken);
    }
}
