using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class AppointmentArchivizationRequest : IRequest<AppointmentArchivizationDTO> 
    { 
        public int Id { get; set; }
        public bool TookPlace { get; set; }
        public string Result { get; set; } = default!;
        public string Remarks { get; set; } = default!;
        public bool WasNecessary { get; set; }
        public bool WasPrescriptionIssued { get; set; }
    }
}
