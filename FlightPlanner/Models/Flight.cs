namespace FlightPlanner.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public bool Equals(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }

            var isSameFrom = From.Equals(flight.From);
            var isSameTo = To.Equals(flight.To);
            var isSameCarrier = Carrier == flight.Carrier;
            var isSameDepartureTime = DepartureTime == flight.DepartureTime;
            var isSameArrivalTime = ArrivalTime == flight.ArrivalTime;

            return isSameFrom && isSameTo && isSameCarrier && isSameDepartureTime && isSameArrivalTime;
        }
    }
}