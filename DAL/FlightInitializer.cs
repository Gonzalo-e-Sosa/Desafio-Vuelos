using Desafio_Vuelos.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Vuelos.DAL
{
    public class FlightInitializer
    {
        public static void Initialize(FlightContext context)
        {
            context.Database.EnsureCreated();

            if (context.Flights.Any())
            {
                return;
            }

            var flights = new List<Flight>
            {
                new() {
                    FlightNumber="AU2401",
                    ArrivalTime= DateTime.Now,
                    Airline="Austral Lineas Aereas",
                    Delayed=true
                },
                new() {
                    FlightNumber="4M5994",
                    ArrivalTime= DateTime.Now,
                    Airline="Latam Argentina",
                    Delayed=false
                },
                new() {
                    FlightNumber="AR2939",
                    ArrivalTime= DateTime.Now,
                    Airline="Aerolineas Argentinas",
                    Delayed=false
                }
            };

            flights.ForEach(f => context.Flights.Add(f));
            context.SaveChanges();
        }
    }
}
