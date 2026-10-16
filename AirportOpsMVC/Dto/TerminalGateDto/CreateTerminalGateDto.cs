namespace AirportOpsMVC.Dto.TerminalGateDto
{
    public class CreateTerminalGateDto
    {
        public int TerminalId { get; set; }

        public string? GateNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
