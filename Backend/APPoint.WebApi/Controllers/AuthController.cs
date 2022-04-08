using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace APPoint.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LoginDTO> Login([FromBody]LoginRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
