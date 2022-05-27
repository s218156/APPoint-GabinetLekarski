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
        internal DbSet<Drug> Drugs { get; set; } = default!;
        internal DbSet<Specialization> Specializations { get; set; } = default!;
        internal DbSet<PatientInfo> PatientInfo { get; set; } = default!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Languages)
                .WithMany(p => p.Users)
                .UsingEntity<UserLanguageMapping>(
                    u => u
                        .HasOne<Language>()
                        .WithMany()
                        .HasForeignKey("LanguageId"),
                    u => u
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId"));

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Drugs)
                .WithMany(p => p.Patients)
                .UsingEntity<DrugPatientMapping>(
                    u => u
                        .HasOne<Drug>()
                        .WithMany()
                        .HasForeignKey("DrugId"),
                    u => u
                        .HasOne<Patient>()
                        .WithMany()
                        .HasForeignKey("PatientId"));
        }
    }
}
