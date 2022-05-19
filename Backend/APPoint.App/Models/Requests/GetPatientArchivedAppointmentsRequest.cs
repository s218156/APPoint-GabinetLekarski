using APPoint.App.Models.DTO;
using MediatR;
namespace APPoint.App.Models.Requests
{
    public class GetPatientArchivedAppointmentsRequest : IRequest<GetPatientArchivedAppointmentsDTO>
    {
        public int Id { get; set; }
    }
}
