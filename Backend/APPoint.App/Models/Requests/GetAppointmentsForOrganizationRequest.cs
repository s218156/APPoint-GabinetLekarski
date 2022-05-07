using APPoint.App.Models.DTO;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class GetAppointmentsForOrganizationRequest : IRequest<GetAppointmentsDTO> { }
}
