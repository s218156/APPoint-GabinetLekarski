namespace APPoint.App.Models.Data.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
