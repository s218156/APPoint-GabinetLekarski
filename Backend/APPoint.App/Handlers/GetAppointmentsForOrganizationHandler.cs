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
    public class GetAppointmentsForOrganizationHandler : IRequestHandler<GetAppointmentsForOrganizationRequest, GetAppointmentsForOrganizationDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetAppointmentsForOrganizationHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public Task<GetAppointmentsForOrganizationDTO> Handle(GetAppointmentsForOrganizationRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetAppointmentsForOrganizationDTO() { Appointments = _appointmentService.GetAppointmentsForOrganization(request.OrganizationId) });
        }
    }
}
