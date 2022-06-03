using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class RoomRegistrationRequest : IRequest<RoomRegistrationDTO>
    {
        public string Number { get; set; } = default!;
        public string Specialization { get; set; } = default!;
    }
}
