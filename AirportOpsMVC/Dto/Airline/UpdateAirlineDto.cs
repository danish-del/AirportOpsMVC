namespace AirportOpsMVC.Dto.Airline
{
    public class UpdateAirlineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
