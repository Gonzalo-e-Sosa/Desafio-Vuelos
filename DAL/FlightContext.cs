using Microsoft.EntityFrameworkCore;
using Desafio_Vuelos.Models;

namespace Desafio_Vuelos.DAL
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().ToTable("Flight");
        }
    }
}
