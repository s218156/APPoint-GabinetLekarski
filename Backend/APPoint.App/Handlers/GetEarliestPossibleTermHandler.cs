using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetEarliestPossibleTermHandler : IRequestHandler<GetEarliestPossibleTermRequest, GetEarliestPossibleTermDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetEarliestPossibleTermHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<GetEarliestPossibleTermDTO> Handle(GetEarliestPossibleTermRequest request, CancellationToken cancellationToken)
        {
            var earliestPossibleTerm = await _appointmentService.GetEarliestPossibleTerm(request.Specialization, request.Length);

            return new GetEarliestPossibleTermDTO() 
            { 
                Date = earliestPossibleTerm.Date,  
                DoctorId = earliestPossibleTerm.User.Id,
                DoctorName = earliestPossibleTerm.User.Name,
                RoomId = earliestPossibleTerm.Room.Id,
                RoomNumber = earliestPossibleTerm.Room.Number
            };
        }
    }
}
