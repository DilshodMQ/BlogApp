using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcApp.Areas.Identity.Data;
using MvcApp.Models;

namespace MvcApp.Data;

public class MvcAppContext : IdentityDbContext<MvcAppUser>
{
    public DbSet<Post>? Posts { get; set; }
    public MvcAppContext(DbContextOptions<MvcAppContext> options)
        : base(options)
    {
       Database.EnsureCreated();
     
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
