using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace APPoint.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class DrugController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DrugController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetDrugsDTO> GetAll()
        {
            return await _mediator.Send(new GetDrugsRequest());
        }
    }
}
