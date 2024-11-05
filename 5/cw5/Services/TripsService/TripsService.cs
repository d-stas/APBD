using AutoMapper;
using cw5.Context;
using cw5.Services.TripsService.Abstract;
using cw5.Services.TripsService.Dto;
using Microsoft.EntityFrameworkCore;

namespace cw5.Services.TripsService;

public class TripsService : ITripsService
{
    private readonly MasterContext _dbContext;
    private readonly IMapper _mapper;

    public TripsService(MasterContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ICollection<TripDto>> GetTripsAsync()
    {
        var trips = await _dbContext.Trip
            .Include(t => t.IdCountries)
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .OrderByDescending(t => t.DateFrom).ToListAsync();

        return trips.Select(t => _mapper.Map<Trip, TripDto>(t)).ToList();
    }

    public async Task<bool> HasClientByPesel(int idTrip, string clientPesel)
    {
        var trip = await _dbContext.Trip
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .FirstAsync();

        return trip.ClientTrips.Any(ct => ct.IdClientNavigation.Pesel == clientPesel);
    }
}