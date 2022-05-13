using Microsoft.EntityFrameworkCore;

namespace APPoint.App.Models.Data
{
    public class DatabaseContext : DbContext
    {
        internal DbSet<Appointment> Appointments { get; set; } = default!;
        internal DbSet<AvailableHours> AvailableHours { get; set; } = default!;
        internal DbSet<User> Users { get; set; } = default!;
        internal DbSet<Patient> Patients { get; set; } = default!;
        internal DbSet<Room> Rooms { get; set; } = default!;
        internal DbSet<UserType> UserTypes { get; set; } = default!;
        internal DbSet<Language> Languages { get; set; } = default!;
        internal DbSet<Salt> Salts { get; set; } = default!;
        internal DbSet<Organization> Organizations { get; set; } = default!;
        internal DbSet<ArchivedAppointment> ArchivedAppointments { get; set; } = default!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
