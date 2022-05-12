using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Models.Data.Repositories
{
    public class AvailableHoursRepository : Repository<AvailableHours>, IAvailableHoursRepository
    {
        public AvailableHoursRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<AvailableHours>> GetAvailableHoursBySpecialization(string specialization)
        {
            return await GetAll()
                .Where(a => a.User.Specialization == specialization)
                .Include(a => a.Room)
                .Include(a => a.User)
                .ToListAsync();       
        }
    }
}
