using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> AddAsync(Room room) => await _roomRepository.AddAsync(room);

        public IEnumerable<Room> GetAll() => _roomRepository.GetAll();
    }
}
