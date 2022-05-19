using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetPatientArchivedAppointmentsHandler : IRequestHandler<GetPatientArchivedAppointmentsRequest, GetPatientArchivedAppointmentsDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetPatientArchivedAppointmentsHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public Task<GetPatientArchivedAppointmentsDTO> Handle(GetPatientArchivedAppointmentsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetPatientArchivedAppointmentsDTO() { Appointments = _appointmentService.GetArchivedAppointmentsByPatientId(request.Id) });

        }
    }
}
