using APPoint.App.Infrastructure;

namespace APPoint.App.Models.Data.Repositories
{
    public interface ISaltRepository : IRepository<Salt>
    {
        Salt? GetByUserId(int userId);
    }
}
