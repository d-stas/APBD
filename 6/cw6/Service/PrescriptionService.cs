using Microsoft.EntityFrameworkCore;
using WebApplication6.Context;
using WebApplication6.Dto;

namespace WebApplication6.Service;

public interface IPrescriptionService
{
    Task<bool> PrescriptionExistsAsync(int id);
    Task<PrescriptionDto.Get> GetByIdAsync(int id);
}

public class PrescriptionService : IPrescriptionService
{
    private readonly DoctorDbContext _doctorDbContext;

    public PrescriptionService(DoctorDbContext doctorDbContext)
    {
        _doctorDbContext = doctorDbContext;
    }

    public async Task<bool> PrescriptionExistsAsync(int id)
    {
        return await _doctorDbContext.Prescriptions.AnyAsync(p => p.IdPrescription == id);
    }

    public async Task<PrescriptionDto.Get> GetByIdAsync(int id)
    {
        var prescription = await _doctorDbContext.Prescriptions
            .Include(p => p.Doctor)
            .Include(p => p.Patient)
            .FirstAsync(p => p.IdPrescription == id);

        var result = new PrescriptionDto.Get()
        {
            IdPrescription = prescription.IdPrescription,
            Patient = new PatientDto.Get()
            {
                IdPatient = prescription.Patient.IdPatient,
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                Birthdate = prescription.Patient.Birthdate
            },
            Doctor = new DoctorDto.Get()
            {
                IdDoctor = prescription.Doctor.IdDoctor,
                FirstName = prescription.Doctor.FirstName,
                LastName = prescription.Doctor.LastName,
                Email = prescription.Doctor.Email
            },
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Medicaments = await _doctorDbContext.PrescriptionMedicaments
                .Include(pm => pm.Medicament)
                .Include(pm => pm.Prescription)
                .Where(pm => pm.IdPrescription == id)
                .Select(pm =>
                    new MedicamentDto.Get()
                    {
                        IdMedicament = pm.IdMedicament,
                        Description = pm.Medicament.Description,
                        Details = pm.Details,
                        Dose = pm.Dose,
                        Name = pm.Medicament.Name,
                        Type = pm.Medicament.Type
                    }).ToListAsync()
        };

        return result;
    }
}