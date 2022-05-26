using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class AppointmentArchivizationRequest : IRequest<AppointmentArchivizationDTO> 
    { 
        public int Id { get; set; }
        public string Result { get; set; } = default!;
        public string PatientRemarks { get; set; } = default!;
        public string VisitRemarks { get; set; } = default!;
        public bool WasNecessary { get; set; }
        public bool WasPrescriptionIssued { get; set; }
        public IEnumerable<DrugDTO> Medicine { get; set; } = default!;
    }
}
