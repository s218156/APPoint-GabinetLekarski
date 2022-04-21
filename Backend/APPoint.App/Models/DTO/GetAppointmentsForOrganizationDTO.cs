using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPoint.App.Models.DTO
{
    public class GetAppointmentsForOrganizationDTO
    {
        public IEnumerable<AppointmentDTO> Appointments { get; set; } = default!;
    }
}
