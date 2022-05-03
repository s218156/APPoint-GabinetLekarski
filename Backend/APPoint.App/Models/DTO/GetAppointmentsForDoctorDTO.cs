using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;

namespace APPoint.App.Models.DTO
{
    public class GetAppointmentsDTO
    {
        public IEnumerable<AppointmentDTO> Monday { get; set; } = default!;
        public IEnumerable<AppointmentDTO> Tuesday { get; set; } = default!;
        public IEnumerable<AppointmentDTO> Wednesday { get; set; } = default!;
        public IEnumerable<AppointmentDTO> Thursday{ get; set; } = default!;
        public IEnumerable<AppointmentDTO> Friday { get; set; } = default!;
        public IEnumerable<AppointmentDTO> Saturday { get; set; } = default!;
        public IEnumerable<AppointmentDTO> Sunday { get; set; } = default!;
    }
}
