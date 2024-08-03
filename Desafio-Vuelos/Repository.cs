namespace Desafio_Vuelos
{
	public class Repository
	{
		List<Flight> flights = new List<Flight>()
		{
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
		};

		public List<Flight> GetFlights() => flights;
		public Flight? GetFlight(string FlightNumber) => flights.Find(f => f.FlightNumber == FlightNumber);
	}

	public class Flight
	{
		public required string FlightNumber { get; set; }
		public DateTime ArrivalTime { get; set; }
		public required string Airline { get; set; }
		public bool Delayed { get; set; }
	}
}