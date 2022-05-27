using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APPoint.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class RegistratorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetPatientsDTO> Patients()
        {
            return await _mediator.Send(new GetPatientsRequest());
        }
    }
}
