using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.Data.Repositories
{
    public class SaltRepository : Repository<Salt>, ISaltRepository
    {
        public SaltRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public Salt? GetByUserId(int userId)
        {
            return GetAll().FirstOrDefault(u => u.UserId == userId);
        }
    }
}
