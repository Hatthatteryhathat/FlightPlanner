using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Models;
using PageResult = FlightPlanner.Models.PageResult;

namespace FlightPlanner
{
    public class FlightStorage
    {
        private static List<Flight> _flights = new List<Flight>();
        private static int _id = 0;

        public static Flight AddFlight(Flight flight)
        {
            flight.Id = ++_id;
            _flights.Add(flight);
            return flight;
        }

        public static Flight GetFlight(int id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }

        public static void Clear()
        {
            _flights.Clear();
            _id = 0;
        }

        public static void DeleteFlight(int id)
        {
            var flight = GetFlight(id);
            if (flight != null)
            {
                _flights.Remove(flight);
            }
        }

        public static Airport[] SearchForAirports(string phrase)
        {
            var searchAirportResult = new List<Airport>();
            phrase = phrase.ToLower().Trim();

            foreach (var flight in _flights)
            {
                if (flight.From.City.ToLower().Contains(phrase) ||
                   flight.From.Country.ToLower().Contains(phrase) ||
                   flight.From.AirportName.ToLower().Contains(phrase))
                {
                    searchAirportResult.Add(flight.From);
                }

                if (flight.To.City.ToLower().Contains(phrase) ||
                   flight.To.Country.ToLower().Contains(phrase) ||
                   flight.To.AirportName.ToLower().Contains(phrase))
                {
                    searchAirportResult.Add(flight.To);
                }
            }

            return searchAirportResult.ToArray();
        }

        public static PageResult SearchFlights(SearchFlightRequest request)
        {
            return new PageResult(_flights);
        }

        public static List<Flight> Flights
        {
            get { return _flights; }
        }
    }
}
