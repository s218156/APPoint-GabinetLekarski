using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetAppointmentsForDoctorHandler : IRequestHandler<GetAppointmentsForDoctorRequest, GetAppointmentsForDoctorDTO>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAppointmentsForDoctorHandler(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetAppointmentsForDoctorDTO> Handle(GetAppointmentsForDoctorRequest request, CancellationToken cancellationToken)
        {
            var doctorId = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if(string.IsNullOrEmpty(doctorId))
            {
                throw new AuthorizationException();
            }

            return Task.FromResult(new GetAppointmentsForDoctorDTO() { Appointments = _appointmentService.GetAppointmentsForDoctor(int.Parse(doctorId)) });
        }
    }
}
