using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace APPoint.WebApi.Controllers
{
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ArchivedAppointmentDTO>> ArchivedAppointments(int id)
        {
            return (await _mediator.Send(new GetPatientArchivedAppointmentsRequest() { Id = id })).Appointments;
        }
    }
}
