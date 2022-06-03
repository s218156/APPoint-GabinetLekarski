namespace APPoint.App.Models.Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
