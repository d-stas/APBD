using AutoMapper;
using cw5.Context;

namespace cw5.Services.TripsService.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Trip, TripDto>()
            .ForMember(d => d.Countries, m => m.MapFrom(s => s.IdCountries))
            .ForMember(d => d.Clients, m => m.MapFrom(s => s.ClientTrips));
        CreateMap<Country, TripCountryDto>();
        CreateMap<ClientTrip, TripClientDto>()
            .ForMember(c => c.FirstName, m => m.MapFrom(s => s.IdClientNavigation.FirstName))
            .ForMember(c => c.LastName, m => m.MapFrom(s => s.IdClientNavigation.LastName));
    }
}