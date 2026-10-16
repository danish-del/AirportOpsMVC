namespace AirportOpsMVC.Dto.Terminal
{
    public class ResponseTerminalDto
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}
