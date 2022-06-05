namespace APPoint.App.Models.Data.Repositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
