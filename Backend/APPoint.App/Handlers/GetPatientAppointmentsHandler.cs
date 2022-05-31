using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetPatientAppointmentsHandler : IRequestHandler<GetPatientAppointmentsRequest, GetPatientAppointmentsDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetPatientAppointmentsHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public Task<GetPatientAppointmentsDTO> Handle(GetPatientAppointmentsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetPatientAppointmentsDTO(_appointmentService.GetAppointmentsByPatientId(request.Id)));

        }
    }
}
