using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;


namespace APPoint.App.Handlers
{
    public class GetAppointmentsForOrganizationHandler : IRequestHandler<GetAppointmentsForOrganizationRequest, GetAppointmentsForOrganizationDTO>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAppointmentsForOrganizationHandler(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetAppointmentsForOrganizationDTO> Handle(GetAppointmentsForOrganizationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            return Task.FromResult(new GetAppointmentsForOrganizationDTO() { Appointments = _appointmentService.GetAppointmentsForOrganization(int.Parse(userId)) });
        }
    }
}
