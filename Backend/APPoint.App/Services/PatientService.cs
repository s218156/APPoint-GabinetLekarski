using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task RegisterPatient(Patient patient)
        {
            await _patientRepository.AddPatientAsync(patient);
        }
    }
}
