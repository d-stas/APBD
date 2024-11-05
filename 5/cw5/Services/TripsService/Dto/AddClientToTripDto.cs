using Microsoft.AspNetCore.Mvc;

namespace cw5.Services.TripsService.Dto;

public class AddClientToTripDto
{
    [FromBody]
    public string FirstName { get; set; }
    [FromBody]
    public string LastName { get; set; }
    [FromBody]
    public string Email { get; set; }
    [FromBody]
    public string Telephone { get; set;}
    [FromBody]
    public string Pesel { get; set; }
    [FromBody]
    public int TripId { get; set; }
    [FromBody]
    public string TripName { get; set; }
    [FromBody]
    public DateTime? PaymentDate { get; set; }
}