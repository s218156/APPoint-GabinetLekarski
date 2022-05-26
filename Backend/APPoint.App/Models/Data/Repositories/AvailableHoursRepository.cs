using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Models.Data.Repositories
{
    public class AvailableHoursRepository : Repository<AvailableHours>, IAvailableHoursRepository
    {
        public AvailableHoursRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<AvailableHours>> GetAvailableHoursBySpecializationAndLanguage(string specialization, string language, DateOnly? date = null)
        {
            var availableHours = GetAll().Where(a => a.User.Specialization.Name == specialization && a.User.Languages.Any(l => l.Name == language));

            if(date is not null)
            {
                availableHours = availableHours.Where(a => a.Start.Day == date.Value.Day);
            }

            return await availableHours.Include(a => a.Room)
                .Include(a => a.User)
                .ToListAsync();       
        }
    }
}
