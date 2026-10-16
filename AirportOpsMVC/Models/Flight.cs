namespace AirportOpsMVC.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; } = string.Empty;

        public string? DepartureAirport { get; set; }

        public string? ArrivalAirport { get; set; }

        public DateTime ScheduledArrival { get; set; }

        public DateTime ScheduledDeparture { get; set; }

        public string? Status { get; set; }

        public bool IsActive { get; set; }
    }
}
