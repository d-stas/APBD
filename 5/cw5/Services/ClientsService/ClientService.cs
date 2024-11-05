using cw5.Context;
using cw5.Services.ClientsService.Abstract;
using cw5.Services.TripsService.Dto;
using Microsoft.EntityFrameworkCore;

namespace cw5.Services.ClientsService;

public class ClientService : IClientService
{
    private readonly MasterContext _dbContext;

    public ClientService(MasterContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> HasTripsForClientIdAsync(int idClient)
    {
        return await _dbContext.ClientTrips.AnyAsync(i => i.IdClient == idClient);
    }

    public async Task DeleteAsync(int idClient)
    {
        _dbContext.Clients.Remove(await _dbContext.Clients.FirstAsync(c => c.IdClient == idClient));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> CheckIfExists(string clientPesel)
    {
        return await _dbContext.Clients.AnyAsync(c => c.Pesel == clientPesel);
    }

    public async Task CreateNewClient(AddClientToTripDto client)
    {
        var newClient = new Client()
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Telephone = client.Telephone,
            Pesel = client.Pesel
        };

        await _dbContext.Clients.AddAsync(newClient);

        await _dbContext.SaveChangesAsync();
    }
}