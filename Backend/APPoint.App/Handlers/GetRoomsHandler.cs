using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.App.Services;
using MediatR;

namespace APPoint.App.Handlers
{
    public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, GetRoomsDTO>
    {
        private readonly IRoomService _roomService;

        public GetRoomsHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public Task<GetRoomsDTO> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = _roomService.GetAll().Select(r => new RoomDTO()
            {
                Id = r.Id,
                Number = r.Number,
                Specialization = r.Specialization
            });

            return Task.FromResult(new GetRoomsDTO(rooms));
        }
    }
}
