using Microsoft.AspNetCore.Identity;

namespace ContactsPlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;
    }
}
