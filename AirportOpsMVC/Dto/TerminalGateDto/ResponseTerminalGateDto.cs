namespace AirportOpsMVC.Dto.TerminalGateDto
{
    public class ResponseTerminalGateDto
    {
        public int Id { get; set; }

        public int TerminalId { get; set; }

        public string? GateNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
