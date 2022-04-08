using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class AppointmentRegistrationRequest : IRequest<AppointmentRegistrationDTO> 
    {
        public DateTime CreationDate { get; set; }
        public DateTime Date { get; set; }
        public int Length { get; set; }
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
