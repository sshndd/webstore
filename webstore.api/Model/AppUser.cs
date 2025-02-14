using Microsoft.AspNetCore.Identity;

namespace webstore.api.Model
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
