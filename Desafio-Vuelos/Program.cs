using Desafio_Vuelos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapGet("/flights", () => new Repository().GetFlights());

app.Run();