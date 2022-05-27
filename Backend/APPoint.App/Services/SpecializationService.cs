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

        public IEnumerable<Specialization> GetAll() => _specializationRepository.GetAll();
    }
}