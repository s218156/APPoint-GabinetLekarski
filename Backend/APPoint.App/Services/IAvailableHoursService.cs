using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IAvailableHoursService
    {
        Task<AvailableHours> AddAsync(AvailableHours availableHours);
        Task DeleteAsync(int id);
        IEnumerable<AvailableHours> GetAll();
    }
}
