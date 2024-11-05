using Microsoft.AspNetCore.Mvc;
using WebApplication6.Service;

namespace WebApplication6.Controllers;

public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    
    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (!await _prescriptionService.PrescriptionExistsAsync(id))
            return NotFound();

        return Ok(await _prescriptionService.GetByIdAsync(id));
    }
}