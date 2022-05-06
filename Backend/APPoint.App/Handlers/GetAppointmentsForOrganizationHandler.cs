using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetAppointmentsForOrganizationHandler : IRequestHandler<GetAppointmentsForOrganizationRequest, GetAppointmentsDTO>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public GetAppointmentsForOrganizationHandler(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public Task<GetAppointmentsDTO> Handle(GetAppointmentsForOrganizationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            var appointments = _appointmentService.GetAppointmentsForOrganization(organizationId);

            return Task.FromResult(new GetAppointmentsDTO()
            {
                Monday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Monday),
                Tuesday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Tuesday),
                Wednesday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Wednesday),
                Thursday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Thursday),
                Friday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Friday),
                Saturday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Saturday),
                Sunday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Sunday),
            });
        }
    }
}
