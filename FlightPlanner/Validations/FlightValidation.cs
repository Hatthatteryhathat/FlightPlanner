using System;
using FlightPlanner.Models;

namespace FlightPlanner.Validations
{
    public class FlightValidation
    {
        public static bool ValidFormat(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }

            if (flight.To == null || flight.From == null)
            {
                return false;
            }

            if ((string.IsNullOrEmpty(flight.Carrier) || string.IsNullOrEmpty(flight.ArrivalTime) ||
                 string.IsNullOrEmpty(flight.DepartureTime) || flight.To == null || flight.From == null) ||
                string.IsNullOrEmpty(flight.To.AirportName) || string.IsNullOrEmpty(flight.To.City) ||
                string.IsNullOrEmpty(flight.To.Country) || string.IsNullOrEmpty(flight.From.AirportName) || string.IsNullOrEmpty(flight.From.City) ||
                string.IsNullOrEmpty(flight.From.Country))
            {
                return false;
            }

            var departureTime = DateTime.Parse(flight.DepartureTime);
            var arrivalTime = DateTime.Parse(flight.ArrivalTime);

            if (arrivalTime <= departureTime)
            {
                return false;
            }

            return true;
        }

        public static bool HasSameAirport(Flight flight)
        {
            if (flight.From.City.ToUpper().Trim() == flight.To.City.ToUpper().Trim() && flight.From.Country.ToUpper().Trim() == flight.To.Country.ToUpper().Trim() &&
                flight.From.AirportName.ToUpper().Trim() == flight.To.AirportName.ToUpper().Trim())
            {
                return true;
            }
            return false;
        }

        public static bool FlightExists(Flight flight)
        {
            if (FlightStorage.Flights.Count == 0)
            {
                return false;
            }

            foreach (Flight newFlight in FlightStorage.Flights)
            {
                if (newFlight.Equals(flight))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsValidRequest(SearchFlightRequest request)
        {
            if (request.From == request.To)
            {
                return false;
            }

            if (request.From == null || request.To == null || request.DepartureDate == null)
            {
                return false;
            }

            return true;
        }
    }
}
