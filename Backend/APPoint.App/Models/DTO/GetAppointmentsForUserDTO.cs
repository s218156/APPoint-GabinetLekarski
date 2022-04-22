using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;

namespace APPoint.App.Models.DTO
{
    public class GetAppointmentsForUserDTO
    {
        public IEnumerable<AppointmentDTO> Appointments { get; set; } = default!;
    }
}
