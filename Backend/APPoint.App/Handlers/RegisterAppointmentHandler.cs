using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using MediatR;

namespace APPoint.App.Handlers
{
    public class RegisterAppointmentHandler : IRequestHandler<AppointmentRegistrationRequest, AppointmentRegistrationDTO>
    {
    }
}
