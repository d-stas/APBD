using Microsoft.EntityFrameworkCore;
using WebApplication6.Context;
using WebApplication6.Dto;
using WebApplication6.Model;

namespace WebApplication6.Service;

public interface IDoctorService
{
    Task<ICollection<DoctorDto.Get>> GetDoctorsAsync();
    Task UpdateDoctorAsync(int id, DoctorDto.Update dto);
    Task DeleteAsync(int id);
    Task<DoctorDto.Get> CreateAsync(DoctorDto.Create dto);
    Task<DoctorDto.Get?> GetDoctorByIdAsync(int id);
}

public class DoctorService : IDoctorService
{
    private readonly DoctorDbContext _doctorDbContext;

    public DoctorService(DoctorDbContext doctorDbContext)
    {
        _doctorDbContext = doctorDbContext;
    }

    public async Task<ICollection<DoctorDto.Get>> GetDoctorsAsync()
    {
        return await _doctorDbContext.Doctors.Select(d => new DoctorDto.Get()
        {
            IdDoctor = d.IdDoctor,
            FirstName = d.FirstName,
            LastName = d.LastName,
            Email = d.Email
        }).ToListAsync();
    }

    public async Task UpdateDoctorAsync(int id, DoctorDto.Update dto)
    { 
        var doctor = _doctorDbContext.Doctors.First(d => d.IdDoctor == id);

        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Email = dto.Email;

        await _doctorDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var doctor = _doctorDbContext.Doctors.First(d => d.IdDoctor == id);

        _doctorDbContext.Doctors.Remove(doctor);

        await _doctorDbContext.SaveChangesAsync();
    }

    public async Task<DoctorDto.Get> CreateAsync(DoctorDto.Create dto)
    {
        var doctor = new Doctor
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        await _doctorDbContext.Doctors.AddAsync(doctor);
        await _doctorDbContext.SaveChangesAsync();

        return new DoctorDto.Get()
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };
    }

    public async Task<DoctorDto.Get?> GetDoctorByIdAsync(int id)
    {
        var result = await _doctorDbContext.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == id);

        return result == null
            ? null
            : new DoctorDto.Get()
            {
                IdDoctor = result.IdDoctor,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email
            };
    }

    private async Task<bool> DoctorExists(int id)
    {
        return await _doctorDbContext.Doctors.AnyAsync(d => d.IdDoctor == id);
    }
}