using Microsoft.AspNetCore.Identity;

namespace NanoHealthTask.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
