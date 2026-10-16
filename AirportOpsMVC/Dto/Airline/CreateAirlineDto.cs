namespace AirportOpsMVC.Dto.Airline
{
    public class CreateAirlineDto
    {
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
