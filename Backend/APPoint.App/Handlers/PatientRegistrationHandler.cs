using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class PatientRegistrationHandler : IRequestHandler<PatientRegistrationRequest, PatientRegistrationDTO>
    {
        private readonly IPatientService _patientService;

        public PatientRegistrationHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<PatientRegistrationDTO> Handle(PatientRegistrationRequest request, CancellationToken cancellationToken)
        {
            await _patientService.RegisterPatient(new Patient()
            {
                Name = request.Name,
                Surname = request.Surname,
                TelephoneNumber = request.TelephoneNumber
            });

            return new PatientRegistrationDTO();
        }
    }
}
