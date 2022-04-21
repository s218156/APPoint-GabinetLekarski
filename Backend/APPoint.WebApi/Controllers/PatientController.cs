using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace APPoint.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(PatientRegistrationRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
