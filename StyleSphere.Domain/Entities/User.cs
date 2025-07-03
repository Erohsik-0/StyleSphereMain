using Microsoft.AspNetCore.Identity;


namespace StyleSphere.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? AvatarUrl { get; set; }

    }
}
