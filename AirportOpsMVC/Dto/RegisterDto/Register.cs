namespace AirportOpsMVC.Dto.RegisterDto
{
    public class Register
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
