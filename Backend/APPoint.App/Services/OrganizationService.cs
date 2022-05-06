using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IEnumerable<PatientDTO> GetAllPatients(int id)
        {
            return _organizationRepository
                .GetAll()
                .Where(o => o.Id == id)
                .SelectMany(o =>
                    o.Users.SelectMany(u =>
                        u.Appointments.Select(a => a.Patient)))
                .Distinct()
                .Select(p => new PatientDTO()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    TelephoneNumber = p.TelephoneNumber
                });
        }
    }
}
