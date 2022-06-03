using System.Security.Claims;
using APPoint.App.Exceptions;
using APPoint.App.Models.Data;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace APPoint.App.Handlers
{
    public class RoomRegistrationHandler : IRequestHandler<RoomRegistrationRequest, RoomRegistrationDTO>
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomRegistrationHandler(IRoomService roomService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _roomService = roomService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RoomRegistrationDTO> Handle(RoomRegistrationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new AuthorizationException();
            }

            var organizationId = _userService.GetOrganizationIdByUserId(int.Parse(userId));

            await _roomService.AddAsync(new Room()
            {
                Number = request.Number,
                Specialization = request.Specialization,
                OrganizationId = organizationId
            });

            return new RoomRegistrationDTO();
        }
    }
}
