using APPoint.App.Exceptions;
using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteAsync(int id)
        {
            var availableHours = _availableHoursRepository.GetAll().FirstOrDefault(a => a.Id == id);

            if(availableHours is null)
            {
                throw new BusinessException();
            }

            await _availableHoursRepository.DeleteAsync(availableHours);
        }

        public IEnumerable<AvailableHours> GetAll() => _availableHoursRepository
            .GetAll()
            .Include(a => a.Room)
            .Include(a => a.User)
            .ThenInclude(u => u.Specialization);
    }
}
