using Desafio_Vuelos.Models;
using Desafio_Vuelos.Repositories;

namespace Desafio_Vuelos.Services
{
	public class FlightService(IFlightRepository flightRepository)
	{
		private readonly IFlightRepository _flightRepository = flightRepository;

		public Task<IEnumerable<Flight>> GetAllFlightsAsync()
		{
			return _flightRepository.GetAllFlightsAsync();
		}

		public Task<Flight?> GetFlightByFlightNumber(string flightNumber)
		{
			return _flightRepository.GetFlightByFlightNumberAsync(flightNumber);
		}

		public Task AddFlightAsync(Flight flight)
		{
			return _flightRepository.AddFlightAsync(flight);
		}

		public Task UpdateFlightAsync(Flight flight)
		{
			return _flightRepository.UpdateFlightAsync(flight);
		}

		public Task DeleteFlightAsync(string flightNumber)
		{
			return _flightRepository.DeleteFlightAsync(flightNumber);
		}
	}
}
