using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface IRoomService
    {
        Task<Room> AddAsync(Room room);
    }
}
