using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Models.Data
{
    public class DatabaseContext : DbContext
    {
        internal DbSet<Appointment> Appointments { get; set; } = default!;
        internal DbSet<AvailableHours> AvailableHours { get; set; } = default!;
        internal DbSet<Employee> Employees { get; set; } = default!;
        internal DbSet<Patient> Patients { get; set; } = default!;
        internal DbSet<Room> Rooms { get; set; } = default!;
        internal DbSet<User> Users { get; set; } = default!;
        internal DbSet<UserType> UserTypes { get; set; } = default!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
