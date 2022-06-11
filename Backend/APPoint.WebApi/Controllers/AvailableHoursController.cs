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
    public class AvailableHoursController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AvailableHoursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AvailableHoursRegistrationDTO> Register(AvailableHoursRegistrationRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new AvailableHoursDeletionRequest() { Id = id });

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetAvailableHoursDTO> GetAll()
        {
            return await _mediator.Send(new GetAvailableHoursRequest());
        }
    }
}
