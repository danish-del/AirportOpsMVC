using Microsoft.AspNetCore.Identity;

namespace AirportOpsMVC.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
