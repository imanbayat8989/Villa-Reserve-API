using Microsoft.AspNetCore.Identity;

namespace Villa_VillaAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
