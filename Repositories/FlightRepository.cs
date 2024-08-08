using Desafio_Vuelos.Models;
using Desafio_Vuelos.DAL;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Vuelos.Repositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlightsAsync();
        Task<Flight?> GetFlightByFlightNumberAsync(string flightNumber);
        Task<Task> AddFlightAsync(Flight flight);
        Task<Task> UpdateFlightAsync(Flight flight);
        Task<Task> DeleteFlightAsync(string flightNumber);
    }

    public class FlightRepository(FlightContext context) : IFlightRepository
    {
        private readonly FlightContext _context = context;

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights.ToListAsync();    
        }

        public async Task<Flight?> GetFlightByFlightNumberAsync(string flightNumber)
        {
            var flight = await _context.Flights.FindAsync(flightNumber);
            return await Task.FromResult(flight);
        }

        public async Task<Task> AddFlightAsync(Flight flight)
        {
            try
            {
                await _context.Flights.AddAsync(flight);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while inserting a flight: {ex.Message}");
                return Task.FromException(ex);
            }
        }

        public async Task<Task> UpdateFlightAsync(Flight flight)
        {
            //var flightToUpdate = _flights.FirstOrDefault(f => f.FlightNumber.Equals(flight.FlightNumber, StringComparison.CurrentCultureIgnoreCase));
            var flightToUpdate = await _context.Flights.FindAsync(flight.FlightNumber);

            if (flightToUpdate == null)
            {
                return Task.FromException(new InvalidOperationException($"Flight with number {flight.FlightNumber} does not exist."));
            }

            flightToUpdate.Airline = flight.Airline;
            flightToUpdate.ArrivalTime = flight.ArrivalTime;
            flightToUpdate.Delayed = flight.Delayed;

            _context.Flights.Update(flightToUpdate);
            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public async Task<Task> DeleteFlightAsync(string flightNumber)
        {
            //var flight = _flights.FirstOrDefault(f => f.FlightNumber.Equals(flightNumber, StringComparison.CurrentCultureIgnoreCase));
            var flightToRemove = await _context.Flights.FindAsync(flightNumber);

            Console.WriteLine(flightToRemove);
            
            if (flightToRemove == null)
            {
                return Task.FromException(new InvalidOperationException($"Flight with number {flightNumber} does not exist."));
            }

            Console.WriteLine(flightToRemove.FlightNumber);

            _context.Flights.Remove(flightToRemove);
            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}