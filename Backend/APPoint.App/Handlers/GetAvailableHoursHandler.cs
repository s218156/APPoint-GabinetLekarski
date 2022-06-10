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
    public class GetAvailableHoursHandler : IRequestHandler<GetAvailableHoursRequest, GetAvailableHoursDTO>
    {
        private readonly IAvailableHoursService _availableHoursService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAvailableHoursHandler(IAvailableHoursService availableHoursService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _availableHoursService = availableHoursService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetAvailableHoursDTO> Handle(GetAvailableHoursRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            var availableHours = _availableHoursService
                .GetAll()
                .Where(a => a.User.OrganizationId == organizationId)
                .Select(a => new AvailableHoursDTO()
                {
                    ShiftStart = a.Start,
                    ShiftEnd = TimeOnly.FromDateTime(a.End),
                    Room = a.Room.Number,
                    DoctorName = a.User.Name,
                    DoctorSurname = a.User.Surname,
                    Specialization = a.User.Specialization.Name
                });

            return Task.FromResult(new GetAvailableHoursDTO()
            {
                Monday = availableHours.Where(a => a.ShiftStart.DayOfWeek == DayOfWeek.Monday),
                Tuesday = availableHours.Where(a => a.ShiftStart.DayOfWeek == DayOfWeek.Tuesday),
                Wednesday = availableHours.Where(a => a.ShiftStart.DayOfWeek == DayOfWeek.Wednesday),
                Thursday = availableHours.Where(a => a.ShiftStart.DayOfWeek == DayOfWeek.Thursday),
                Friday = availableHours.Where(a => a.ShiftStart.DayOfWeek == DayOfWeek.Friday),
                Saturday = availableHours.Where(a => a.ShiftStart.DayOfWeek == DayOfWeek.Saturday)
            });
        }
    }
}
