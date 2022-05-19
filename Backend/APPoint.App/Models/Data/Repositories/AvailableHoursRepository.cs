using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Models.Data.Repositories
{
    public class AvailableHoursRepository : Repository<AvailableHours>, IAvailableHoursRepository
    {
        public AvailableHoursRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<AvailableHours>> GetAvailableHoursBySpecializationAndLanguage(string specialization, string language)
        {
            return await GetAll()
                .Where(a => a.User.Specialization == specialization && a.User.Languages.Any(l => l.Name == language))
                .Include(a => a.Room)
                .Include(a => a.User)
                .ToListAsync();       
        }
    }
}
