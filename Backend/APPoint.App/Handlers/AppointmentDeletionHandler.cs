using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class AppointmentDeletionHandler : IRequestHandler<AppointmentDeletionRequest, AppointmentDeletionDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentDeletionHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<AppointmentDeletionDTO> Handle(AppointmentDeletionRequest request, CancellationToken cancellationToken)
        {
            await _appointmentService.RemoveAppointment(request.Id);

            return new AppointmentDeletionDTO();
        }
    }
}
