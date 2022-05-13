using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;

namespace APPoint.App.Models.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Length { get; set; }
        public PatientDTO Patient { get; set; } = default!;
        public RoomDTO Room { get; set; } = default!;
    }
}
