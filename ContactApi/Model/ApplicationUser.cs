using Microsoft.AspNetCore.Identity;

namespace ContactApi.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
