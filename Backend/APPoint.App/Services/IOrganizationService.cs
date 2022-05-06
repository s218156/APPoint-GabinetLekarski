using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IOrganizationService
    {
        IEnumerable<PatientDTO> GetAllPatients(int id);
    }
}
