using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class AppointmentRegistrationHandler : IRequestHandler<AppointmentRegistrationRequest, AppointmentRegistrationDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentRegistrationHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<AppointmentRegistrationDTO> Handle(AppointmentRegistrationRequest request, CancellationToken cancellationToken)
        {
            await _appointmentService.RegisterAppointment(new Appointment()
            {
                Date = request.Date,
                Length = request.Length,
                PatientId = request.PatientId,
                UserId = request.UserId,
                RoomId = request.RoomId
            });

            return new AppointmentRegistrationDTO();
        }
    }
}
