using Microsoft.AspNetCore.Identity;

namespace InoversityIdentity.Distribution.WebApi.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FavoriteColor { get; set; }
}