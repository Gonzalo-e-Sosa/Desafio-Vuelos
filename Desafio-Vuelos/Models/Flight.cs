namespace Desafio_Vuelos.Models
{
	public class Flight
	{
		public required string FlightNumber { get; set; }
		public DateTime ArrivalTime { get; set; }
		public required string Airline { get; set; }
		public bool Delayed { get; set; }
	}
}
