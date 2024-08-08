using Desafio_Vuelos.Models;
using Desafio_Vuelos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Vuelos.Controllers
{
    public class FlightController(FlightService flightService) : Controller
    {
        private readonly FlightService _flightService = flightService;
        
        // GET: FlightController
        public async Task<ActionResult> Index()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            var sortedFligts = flights.OrderBy(f => f.ArrivalTime).ToList();
            return View(flights);
        }

        // GET: FlightController/Details/AU2401
        public async Task<ActionResult> Details(string flightNumber)
        {
            var flight = await _flightService.GetFlightByFlightNumber(flightNumber);
            return View(flight);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection formCollection)
        {
            try
            {
                string flightNumber = string.Empty;
                DateTime arrivalTime = DateTime.MinValue;
                string airline = string.Empty;
                bool delayed = false;

                if (
                    formCollection.ContainsKey("FlightNumber") && 
                    !string.IsNullOrWhiteSpace(formCollection["FlightNumber"])
                )
                { 
                    flightNumber = formCollection["FlightNumber"].ToString();
                }

                if (
                    formCollection.ContainsKey("ArrivalTime") && 
                    DateTime.TryParse(formCollection["ArrivalTime"], out var parsedArrivalTime)
                ) 
                {
                    arrivalTime = parsedArrivalTime;
                }

                if (
                    formCollection.ContainsKey("Airline") &&
                    !string.IsNullOrWhiteSpace(formCollection["Airline"])
                )
                {
                    airline = formCollection["Airline"].ToString();
                }

                if (
                    formCollection.ContainsKey("Delayed") 
                    && bool.TryParse(formCollection["Delayed"], out var parsedDelayed)
                )
                {
                    delayed = parsedDelayed;
                }

                Flight newFlight = new()
                {
                    FlightNumber = flightNumber,
                    ArrivalTime = arrivalTime,
                    Airline = airline,
                    Delayed = delayed
                };

                await _flightService.AddFlightAsync(newFlight);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "An error occurred while creating a flight.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the flight. Please try again.");
                return View();
            }
        }

        // GET: FlightController/Edit/AU2401
        public async Task<ActionResult> Edit(string flightNumber)
        {
            var flight = await _flightService.GetFlightByFlightNumber(flightNumber);
            return View(flight);
        }

        // POST: FlightController/Edit/AU2401
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string flightNumber, IFormCollection formCollection)
        {
            try
            {
                DateTime arrivalTime = DateTime.MinValue;
                string airline = string.Empty;
                bool delayed = false;

                if (
                    formCollection.ContainsKey("ArrivalTime") &&
                    DateTime.TryParse(formCollection["ArrivalTime"], out var parsedArrivalTime)
                )
                {
                    arrivalTime = parsedArrivalTime;
                }

                if (
                    formCollection.ContainsKey("Airline") &&
                    !string.IsNullOrWhiteSpace(formCollection["Airline"])
                )
                {
                    airline = formCollection["Airline"].ToString();
                }

                if (
                    formCollection.ContainsKey("Delayed")
                    && bool.TryParse(formCollection["Delayed"], out var parsedDelayed)
                )
                {
                    delayed = parsedDelayed;
                }

                Flight newFlight = new()
                {
                    FlightNumber = flightNumber,
                    ArrivalTime = arrivalTime,
                    Airline = airline,
                    Delayed = delayed
                };

                await _flightService.UpdateFlightAsync(newFlight);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/
        public async Task<ActionResult> Delete()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return View(flights);
        }

        // POST: FlightController/Delete/AU2401
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string flightNumber, IFormCollection formCollection)
        {
            try
            {
                await _flightService.DeleteFlightAsync(flightNumber);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
