namespace AirportOpsMVC.Dto.Terminal
{
    public class UpdateTerminalDto
    {
        public int Id { get; set; }
        public int AirportId { get; set; }

        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}
