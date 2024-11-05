using cw5.Services.TripsService.Dto;

namespace cw5.Services.TripsService.Abstract;

public interface ITripsService
{
    public Task<ICollection<TripDto>> GetTripsAsync();
    public Task<bool> HasClientByPesel(int idTrip, string clientPesel);
}