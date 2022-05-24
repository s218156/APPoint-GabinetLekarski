using APPoint.App.Models.Data;
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
        public async Task<IEnumerable<Drug>> GetAll()
        {
            return (await _mediator.Send(new GetDrugsRequest())).Drugs;
        }
    }
}
