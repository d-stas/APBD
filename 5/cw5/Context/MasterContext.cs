using Microsoft.EntityFrameworkCore;

namespace cw5.Context;

public class MasterContext : DbContext
{
    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
        
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientTrip> ClientTrips { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryTrip> CountryTrips { get; set; }
    public DbSet<Trip> Trips { get; set; }

}