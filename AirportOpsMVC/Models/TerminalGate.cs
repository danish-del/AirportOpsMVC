namespace AirportOpsMVC.Models
{
    public class TerminalGate
    {
        public int Id { get; set; }

        public int TerminalId { get; set; }

        public string? GateNumber { get; set; }

        public bool IsActive { get; set; }

        public Terminal? Terminal { get; set; }
    }
}
