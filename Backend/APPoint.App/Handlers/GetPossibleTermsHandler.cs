using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetPossibleTermsHandler : IRequestHandler<GetPossibleTermsRequest, GetPossibleTermsDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetPossibleTermsHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<GetPossibleTermsDTO> Handle(GetPossibleTermsRequest request, CancellationToken cancellationToken)
        {
            var terms = (await _appointmentService.GetPossibleTerms(request.Date, request.Specialization, request.Length, request.Language))
                .Select(t => new GetEarliestPossibleTermDTO
                {
                    Date = t.Date,
                    DoctorId = t.User.Id,
                    DoctorName = t.User.Name,
                    DoctorSurname = t.User.Surname,
                    RoomId = t.Room.Id,
                    RoomNumber = t.Room.Number
                });

            return new GetPossibleTermsDTO() { Terms = terms };
        }
    }
}
