using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class AvailableHoursService : IAvailableHoursService
    {
        private readonly IAvailableHoursRepository _availableHoursRepository;

        public AvailableHoursService(IAvailableHoursRepository availableHoursRepository)
        {
            _availableHoursRepository = availableHoursRepository;
        }

        public async Task<AvailableHours> AddAsync(AvailableHours availableHours) => await _availableHoursRepository.AddAsync(availableHours);

        public IEnumerable<AvailableHours> GetAll() => _availableHoursRepository.GetAll();
    }
}
