using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IAvailableHoursService
    {
        Task<AvailableHours> AddAsync(AvailableHours availableHours);
        IEnumerable<AvailableHours> GetAll();
    }
}
