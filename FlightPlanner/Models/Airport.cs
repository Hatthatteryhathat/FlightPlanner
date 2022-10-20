using System.Text.Json.Serialization;

namespace FlightPlanner.Models
{
    public class Airport
    {
        public string Country { get; set; }
        public string City { get; set; }
        [JsonPropertyName("airport")]
        public string AirportName { get; set; }

        public bool Equals(Airport airport)
        {
            if (airport == null)
            {
                return false;
            }

            var isSameCountry = Country == airport.Country;
            var isSameCity = City == airport.City;
            var isSameAirportName = AirportName == airport.AirportName;

            return isSameCountry && isSameCity && isSameAirportName;
        }
    }
}