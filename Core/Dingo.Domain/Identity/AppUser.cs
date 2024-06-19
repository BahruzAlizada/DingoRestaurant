using Microsoft.AspNetCore.Identity;

namespace Dingo.Domain.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public bool Status { get; set; }
    }
}
