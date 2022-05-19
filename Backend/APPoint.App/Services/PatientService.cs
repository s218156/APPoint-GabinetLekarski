using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<PatientDTO> GetPatientsByOrganizationId(int organizationId)
        {
            return _patientRepository
                .GetAll()
                .Where(p => p.OrganizationID == organizationId)
                .Select(p => new PatientDTO()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    TelephoneNumber = p.TelephoneNumber
                });
        }

        public async Task RegisterPatient(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }
    }
}
