using Microsoft.AspNetCore.Identity;

namespace BiteFightRevival.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public DateTime BirthDate { get; set; }
}