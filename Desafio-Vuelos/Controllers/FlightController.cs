using Desafio_Vuelos.Models;
using Desafio_Vuelos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Vuelos.Controllers
{
    public class FlightController(FlightService flightService) : Controller
    {
        private readonly FlightService _flightService = flightService;

        // GET
        public async Task<IActionResult> Index()
        { 
            var flights = await _flightService.GetAllFlightsAsync();
            return View(flights);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                await _flightService.AddFlightAsync(flight);
                return RedirectToAction(nameof(Index));
            }

            return View(flight);
        }

        // GET
        public IActionResult Edit()
        {
            /*
             * param string flightNumber
            var flight = await _flightService.GetFlightByFlightNumber(flightNumber);
            if (flight == null)
            {
                return NotFound();
            }*/
            return View();
        }

        // POST
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string flightNumber, Flight flight)
        {
            if (flightNumber != flight.FlightNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _flightService.UpdateFlightAsync(flight);
                return RedirectToAction(nameof(Index));
            }

            return View(flight);
        }

        // GET
        public IActionResult Delete()
        {
            /*
             * string flightNumber
            var flight = await _flightService.GetFlightByFlightNumber(flightNumber);
            if (flight == null)
            {
                return NotFound();
            }*/

            return View();
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string flightNumber)
        {
            await _flightService.DeleteFlightAsync(flightNumber);
            return RedirectToAction(nameof(Index));
        }
    }
}
