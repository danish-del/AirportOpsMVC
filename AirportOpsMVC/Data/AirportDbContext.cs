using AirportOpsMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirportOpsMVC.Data
{
    public class AirportDbContext : IdentityDbContext<AppUser>
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options)
        {
            
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<TerminalGate> TerminalGates { get; set; }
    }
}
