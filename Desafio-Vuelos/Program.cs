using Desafio_Vuelos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapGet("/flights", () => new Repository().GetFlights());

app.MapGet("/flights/{flightNumber}", (string flightNumber) => {
	var flight = new Repository().GetFlight(flightNumber.ToUpper());

	return flight == null
		? Results.NotFound()
		: Results.Ok(flight);
});

app.Run();