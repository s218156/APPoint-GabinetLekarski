using APPoint.App.Models.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APPoint.App.Models.Requests
{
    public class GetEarliestPossibleTermRequest : IRequest<GetEarliestPossibleTermDTO>
    {
        [FromQuery]
        public string Specialization { get; set; } = default!;
        [FromQuery]
        public int Length { get; set; }
        [FromQuery]
        public string Language { get; set; } = default!;
    }
}
