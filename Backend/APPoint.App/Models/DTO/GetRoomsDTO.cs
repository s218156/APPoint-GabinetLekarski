namespace APPoint.App.Models.DTO
{
    public class GetRoomsDTO : List<RoomDTO>
    {
        public GetRoomsDTO(IEnumerable<RoomDTO> collection) : base(collection) { }
    }
}
