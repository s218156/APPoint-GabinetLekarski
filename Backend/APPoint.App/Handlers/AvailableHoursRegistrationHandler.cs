using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class AvailableHoursRegistrationHandler : IRequestHandler<AvailableHoursRegistrationRequest, AvailableHoursRegistrationDTO>
    {
        private readonly IAvailableHoursService _availableHoursService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AvailableHoursRegistrationHandler(IAvailableHoursService availableHoursService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _availableHoursService = availableHoursService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AvailableHoursRegistrationDTO> Handle(AvailableHoursRegistrationRequest request, CancellationToken cancellationToken)
        {
            if(AreConflictingAvailableHoursPresent(request)) 
            {
                throw new BusinessException() { ErrorCode = Constants.ErrorCode.AvailableHoursAlreadyRegisteredForThatPeriodOfTime };
            }

            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            var availableHours = new AvailableHours()
            {
                UserId = request.DoctorId,
                Start = request.Start,
                End = request.End,
                RoomId = request.RoomId
            };

            await _availableHoursService.AddAsync(availableHours);

            return new AvailableHoursRegistrationDTO();
        }

        private bool AreConflictingAvailableHoursPresent(AvailableHoursRegistrationRequest request) => _availableHoursService.GetAll()
                .Where(a => a.UserId == request.DoctorId &&
                    a.Start.Date == request.Start.Date)
                .Any(a => a.Start >= request.Start && a.Start <= request.End ||
                    a.End >= request.Start && a.End <= request.End ||
                    a.Start <= request.Start && a.End >= request.End);
    }
}
