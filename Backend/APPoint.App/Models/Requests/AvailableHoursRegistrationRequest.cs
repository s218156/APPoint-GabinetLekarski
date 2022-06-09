using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class AvailableHoursRegistrationRequest : IRequest<AvailableHoursRegistrationDTO>
    {
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
