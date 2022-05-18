using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class AppointmentDeletionRequest : IRequest<AppointmentDeletionDTO>
    {
        public int Id { get; set; }
    }
}
