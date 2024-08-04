using Desafio_Vuelos.Models;

namespace Desafio_Vuelos.Repositories
{
	public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task<Flight?> GetFlightByFlightNumberAsync(string flightNumber);
        Task AddFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(string flightNumber);
    }

    public class FlightRepository : IFlightRepository
    {
        // sample data
        private readonly List<Flight> _flights = [
            new() {
                FlightNumber="AU2401",
                ArrivalTime= new DateTime(),
                Airline="Austral Lineas Aereas",
                Delayed=true
            },
            new(){
                FlightNumber="4M5994",
                ArrivalTime= new DateTime(),
                Airline="Latam Argentina",
                Delayed=false
            },
            new(){
                FlightNumber="AR2939",
                ArrivalTime= new DateTime(),
                Airline="Aerolineas Argentinas",
                Delayed=false
            }
        ];

        public Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return Task.FromResult<IEnumerable<Flight>>(_flights);
        }

        public Task<Flight?> GetFlightByFlightNumberAsync(string flightNumber)
        {
            var flight = _flights.FirstOrDefault(f => f.FlightNumber.Equals(flightNumber, StringComparison.CurrentCultureIgnoreCase));

            return Task.FromResult<Flight?>(flight);
        }

        public Task AddFlightAsync(Flight flight)
        {
            // validate before add
            _flights.Add(flight);
            return Task.CompletedTask;
        }

        public Task UpdateFlightAsync(Flight flight)
        {
			var flightToUpdate = _flights.FirstOrDefault(f => f.FlightNumber.Equals(flight.FlightNumber, StringComparison.CurrentCultureIgnoreCase));

            if (flightToUpdate == null)
            {
                return Task.FromException(new InvalidOperationException($"Flight with number {flight.FlightNumber} does not exist."));
            }

            // validate before assing
            flightToUpdate.Airline = flight.Airline;
            flightToUpdate.ArrivalTime = flight.ArrivalTime;
            flightToUpdate.Delayed = flight.Delayed;

            return Task.CompletedTask;
        }

        public Task DeleteFlightAsync(string flightNumber)
        {
            var flight = _flights.FirstOrDefault(f => f.FlightNumber.Equals(flightNumber, StringComparison.CurrentCultureIgnoreCase));

            if (flight == null)
            {
                return Task.FromException(new InvalidOperationException($"Flight with number {flightNumber} does not exist."));
            }

            _flights.Remove(flight);
            return Task.CompletedTask;
        }
    }
}