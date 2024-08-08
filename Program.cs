using Desafio_Vuelos.DAL;
using Desafio_Vuelos.Repositories;
using Desafio_Vuelos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext with the connection string
var connectionString = builder.Configuration.GetConnectionString("FlightContext");
builder.Services.AddDbContext<FlightContext>(options => options.UseSqlServer(connectionString));

// Add repository and service to the builder.
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<FlightService>();

var app = builder.Build();

// Initialize the database with seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FlightContext>();
    FlightInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
