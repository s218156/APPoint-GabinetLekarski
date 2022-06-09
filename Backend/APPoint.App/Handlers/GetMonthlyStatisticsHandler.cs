using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetMonthlyStatisticsHandler : IRequestHandler<GetMonthlyStatisticsRequest, GetMonthlyStatisticsDTO>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public GetMonthlyStatisticsHandler(IUserService userService, IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetMonthlyStatisticsDTO> Handle(GetMonthlyStatisticsRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            return Task.FromResult(_appointmentService.GetMonthlyStatisticsForOrganization(organizationId, request.Month, request.Year));
        }
    }
}
