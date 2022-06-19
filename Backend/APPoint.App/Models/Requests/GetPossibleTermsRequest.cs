using APPoint.App.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using MediatR;


namespace APPoint.App.Models.Requests
{
    public class GetPossibleTermsRequest : IRequest<GetPossibleTermsDTO>
    {
        [FromQuery]
        public DateOnly Date { get; set; }
        [FromQuery]
        public string Specialization { get; set; } = default!;
        [FromQuery]
        public string Language { get; set; } = default!;
        [FromQuery]
        public int Length { get; set; } = default!;
    }
}
