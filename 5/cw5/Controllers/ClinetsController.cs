using cw5.Services.ClientsService.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace cw5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _service;

    public ClientsController(IClientService service)
    {
        _service = service;
    }
    
    [HttpDelete("{idClient}")]
    public async Task<IActionResult> Delete(int idClient)
    {
        var hasTrips = await _service.HasTripsForClientIdAsync(idClient);

        if (hasTrips)
            return Conflict();

        await _service.DeleteAsync(idClient);

        return NoContent();
    }
}