using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class GetPatientAppointmentsRequest : IRequest<GetPatientAppointmentsDTO>
    {
        public int Id { get; set; }
    }
}
