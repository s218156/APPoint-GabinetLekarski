using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetAppointmentsForUserHandler : IRequestHandler<GetAppointmentsForUserRequest, GetAppointmentsForUserDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetAppointmentsForUserHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public Task<GetAppointmentsForUserDTO> Handle(GetAppointmentsForUserRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetAppointmentsForUserDTO() { Appointments = _appointmentService.GetAppointmentsForUser(request.UserId) });
        }
    }
}
