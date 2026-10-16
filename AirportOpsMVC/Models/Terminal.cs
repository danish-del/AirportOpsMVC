namespace AirportOpsMVC.Models
{
    public class Terminal
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public Airport? Airport { get; set; }
    }
}
