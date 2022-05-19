using APPoint.App.Infrastructure;

namespace APPoint.App.Models.Data.Repositories
{
    public interface IAvailableHoursRepository : IRepository<AvailableHours>
    {
        Task<IEnumerable<AvailableHours>> GetAvailableHoursBySpecializationAndLanguage(string specialization, string language);
    }
}
