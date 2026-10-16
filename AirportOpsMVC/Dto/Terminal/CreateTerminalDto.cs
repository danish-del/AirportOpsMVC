namespace AirportOpsMVC.Dto.Terminal
{
    public class CreateTerminalDto
    {
        public int AirportId { get; set; }
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}
