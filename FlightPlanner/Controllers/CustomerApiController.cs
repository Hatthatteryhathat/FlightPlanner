using FlightPlanner.Models;
using FlightPlanner.Validations;
using Microsoft.AspNetCore.Mvc;


namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        [Route("airports")]
        [HttpGet]
        public IActionResult SearchAirports(string search)
        {
            var airports = FlightStorage.SearchForAirports(search);
            return Ok(airports);
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult SearchFlights(SearchFlightRequest request)
        {
            if (!FlightValidation.IsValidRequest(request))
            {
                return BadRequest();
            }

            return Ok(FlightStorage.SearchFlights(request));
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult SearchFlightsId(int id)
        {
            var flight = FlightStorage.GetFlight(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }
    }
}