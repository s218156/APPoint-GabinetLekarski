using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{ 
    public class PatientInfoService : IPatientInfoService
    {
        private readonly IPatientInfoRepository _patientInfoRepository;

        public PatientInfoService(IPatientInfoRepository patientInfoRepository)
        {
            _patientInfoRepository = patientInfoRepository;
        }

        public async Task AddAsync(PatientInfo patientInfo) => await _patientInfoRepository.AddAsync(patientInfo);  
    }
}
