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
        private readonly IAppointmentService appointmentService;

        public AppointmentRegistrationHandler(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public async Task<AppointmentRegistrationDTO> Handle(AppointmentRegistrationRequest request, CancellationToken cancellationToken)
        {
            await appointmentService.RegisterAppointment(new Appointment()
            {
                CreationDate = DateTime.Now,
                Date = DateTime.Now,
                Length = 60,
                PatientId = 1,
                UserId = 2,
                RoomId = 1
            });

            return new AppointmentRegistrationDTO();
        }
    }
}
