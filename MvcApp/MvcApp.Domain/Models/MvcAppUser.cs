using Microsoft.AspNetCore.Identity;
using MvcApp.Models;


namespace MvcApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MvcAppUser class
public class MvcAppUser : IdentityUser
{
    public List<Post>? Posts { get; set; }
}

