using Desafio_Vuelos.Repositories;
using Desafio_Vuelos.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios (agregar controladores con vistas y dependencias)
builder.Services.AddControllersWithViews();

// Registrar el repositorio y el servicio
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<FlightService>();

var app = builder.Build();

// Configurar el middleware de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Flight}/{action=Index}"
);

app.Run();