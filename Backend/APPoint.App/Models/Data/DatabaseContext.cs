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
        internal DbSet<Prescription> Prescriptions { get; set; } = default!;
        internal DbSet<UserLanguageMapping> UserLanguageMappings { get; set; } = default!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Languages)
                .WithMany(p => p.Users)
                .UsingEntity<UserLanguageMapping>(
                    u => u
                        .HasOne(u => u.Language)
                        .WithMany(u => u.UserLanguageMappings)
                        .HasForeignKey(ulm => ulm.LanguageId),
                    u => u
                        .HasOne(l => l.User)
                        .WithMany(l => l.UserLanguageMappings)
                        .HasForeignKey(ulm => ulm.UserId));

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Drugs)
                .WithMany(p => p.Patients)
                .UsingEntity<Prescription>(
                    u => u
                        .HasOne(p => p.Drug)
                        .WithMany(p => p.Prescriptions)
                        .HasForeignKey(p => p.DrugId),
                    u => u
                        .HasOne(d => d.Patient)
                        .WithMany(p => p.Prescriptions)
                        .HasForeignKey(p => p.PatientId));
        }
    }
}
