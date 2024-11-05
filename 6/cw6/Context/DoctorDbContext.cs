using Microsoft.EntityFrameworkCore;
using WebApplication6.Model;

namespace WebApplication6.Context;

public class DoctorDbContext : DbContext
{
    public DoctorDbContext()
    {
    }

    public DoctorDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Prescription>(e =>
            e.HasData(new List<Prescription>
            {
                new()
                {
                    IdPrescription = 1,
                    IdPatient = 1,
                    IdDoctor = 1,
                    Date = new DateTime(2023, 02, 12),
                    DueDate = new DateTime(2023, 04, 23)
                },
                new()
                {
                    IdPrescription = 2,
                    IdPatient = 2,
                    IdDoctor = 1,
                    Date = new DateTime(2023, 05, 22),
                    DueDate = new DateTime(2023, 09, 13)
                }
            }));
        
        modelBuilder.Entity<Patient>(e =>
            e.HasData(new List<Patient>
            {
                new()
                {
                    IdPatient = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = new DateTime(1990, 02, 13)
                },
                new()
                {
                    IdPatient = 2,
                    FirstName = "John",
                    LastName = "Smith",
                    Birthdate = new DateTime(1992, 04, 01)
                },
            }));
        
        modelBuilder.Entity<Doctor>(e =>
            e.HasData(new List<Doctor>
            {
                new()
                {
                    IdDoctor = 1,
                    FirstName = "Karol",
                    LastName = "Narcyz",
                    Email = "knarcyz@raczarnia.com"
                },
                new()
                {
                    IdDoctor = 2,
                    FirstName = "Agnieszka",
                    LastName = "Wojtaszek",
                    Email = "awojtaszek@raczarnia.com"
                },
            }));

        modelBuilder.Entity<Medicament>(e =>
            e.HasData(new List<Medicament>
            {
                new()
                {
                    IdMedicament = 1,
                    Name = "Pavulon",
                    Description = "Nic tak nie rozluznia",
                    Type = "Lodzki specjal na wszystkie dolegliwosci"
                },
                new()
                {
                    IdMedicament = 2,
                    Name = "Etopiryna",
                    Description = "Przypomina o niej Gozdzikowa",
                    Type = "Lek na bol glowy"
                }
            }));

        modelBuilder.Entity<PrescriptionMedicament>(e =>
            e.HasData(new List<PrescriptionMedicament>
            {
                new()
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Details = "Do podania w karetce",
                    Dose = 999
                },
                new()
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Details = "W przypadkach naglych bolow glowy"
                }
            }));
        
    }
}