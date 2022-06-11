using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IPatientInfoService
    {
        Task AddAsync(PatientInfo patientInfo);
    }
}
