using APPoint.App.Models.Requests;
using APPoint.App.Models.DTO;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Archive(AppointmentArchivizationRequest request)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetEarliestPossibleTermDTO> GetEarliestPossibleTerm([FromQuery] GetEarliestPossibleTermRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}