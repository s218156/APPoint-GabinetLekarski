using APPoint.App.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(AppointmentRegistrationRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Modify(AppointmentModificationRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(AppointmentDeletionRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}