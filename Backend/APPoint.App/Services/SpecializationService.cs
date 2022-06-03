using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;

        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }

        public async Task<Specialization> AddAsync(Specialization specialization) => await _specializationRepository.AddAsync(specialization);

        public IEnumerable<Specialization> GetAll() => _specializationRepository.GetAll();
    }
}