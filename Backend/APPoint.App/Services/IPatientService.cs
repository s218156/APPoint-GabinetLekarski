using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;

namespace APPoint.App.Services
{
    public interface IPatientService
    {
        Task RegisterPatient(Patient patient);
        IEnumerable<PatientDTO> GetPatientsByOrganizationId(int organizationId);
    }
}
