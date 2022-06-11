using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace APPoint.App.Handlers
{
    public class PatientRegistrationHandler : IRequestHandler<PatientRegistrationRequest, PatientRegistrationDTO>
    {
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PatientRegistrationHandler(IPatientService patientService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _patientService = patientService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PatientRegistrationDTO> Handle(PatientRegistrationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));
            await _patientService.RegisterPatient(new Patient()
            {
                Name = request.Name,
                Surname = request.Surname,
                TelephoneNumber = request.TelephoneNumber,
                Sex = request.Sex,
                OrganizationID = organizationId
            });

            return new PatientRegistrationDTO();
        }
    }
}
