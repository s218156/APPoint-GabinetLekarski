using APPoint.App.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace APPoint.App.Models.Requests
{
    public class GetMonthlyStatisticsRequest : IRequest<GetMonthlyStatisticsDTO>
    {
        [FromQuery]
        public int Month { get; set; }
        [FromQuery]
        public int Year { get; set; }
    }
}
