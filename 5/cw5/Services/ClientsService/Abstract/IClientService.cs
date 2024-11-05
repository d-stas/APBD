using cw5.Services.TripsService.Dto;

namespace cw5.Services.ClientsService.Abstract;

public interface IClientService
{
    public Task<bool> HasTripsForClientIdAsync(int idClient);
    public Task DeleteAsync(int idClient);
    public Task<bool> CheckIfExists(string clientPesel);
    public Task CreateNewClient(AddClientToTripDto client);
}