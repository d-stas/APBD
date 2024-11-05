using Microsoft.AspNetCore.Mvc;
using WebApplication6.Dto;
using WebApplication6.Service;

namespace WebApplication6.Controllers;

[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;
    
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await _doctorService.GetDoctorsAsync();

        if (!doctors.Any())
            return NotFound();
        
        return Ok(doctors);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id);

        if (doctor == null)
            return NotFound();

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorDto.Create dto)
    {
        var result = await _doctorService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), result.IdDoctor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id);

        if (doctor == null)
            return NotFound();

        await _doctorService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto.Update dto)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id);

        if (doctor == null)
            return NotFound();

        await _doctorService.UpdateDoctorAsync(id, dto);

        //https://www.rfc-editor.org/rfc/rfc9110.html#name-put If the target resource does have a current representation and that representation is successfully modified in accordance with the state of the enclosed representation, then the origin server MUST send either a 200 (OK) or a 204 (No Content) response to indicate successful completion of the request
        return NoContent();
    }
}