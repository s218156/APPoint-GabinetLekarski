using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Models.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public User? GetById(int id)
        {
            return GetAll().Include(u => u.UserType).FirstOrDefault(u => u.Id == id);
        }
    }
}
