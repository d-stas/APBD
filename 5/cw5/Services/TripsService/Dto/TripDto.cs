namespace cw5.Services.TripsService.Dto;

public class TripDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public ICollection<TripCountryDto> Countries { get; set; } = new List<TripCountryDto>();
    public ICollection<TripClientDto> Clients { get; set; } = new List<TripClientDto>();
}

public class TripCountryDto
{
    public string Name { get; set; }
}

public class TripClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}