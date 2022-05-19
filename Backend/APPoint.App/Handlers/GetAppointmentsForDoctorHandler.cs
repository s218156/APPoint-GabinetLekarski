using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetAppointmentsForDoctorHandler : IRequestHandler<GetAppointmentsForDoctorRequest, GetAppointmentsDTO>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAppointmentsForDoctorHandler(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetAppointmentsDTO> Handle(GetAppointmentsForDoctorRequest request, CancellationToken cancellationToken)
        {
            var doctorId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if(string.IsNullOrEmpty(doctorId))
            {
                throw new AuthorizationException();
            }

            var appointments = _appointmentService.GetAppointmentsForDoctor(int.Parse(doctorId));

            return Task.FromResult(new GetAppointmentsDTO() 
            { 
                Monday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Monday),
                Tuesday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Tuesday),
                Wednesday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Wednesday),
                Thursday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Thursday),
                Friday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Friday),
                Saturday = appointments.Where(a => a.Date.DayOfWeek == DayOfWeek.Saturday)
            });
        }
    }
}
