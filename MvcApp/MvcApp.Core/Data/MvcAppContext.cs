using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using MvcApp.Areas.Identity.Data;

namespace MvcApp.Data;

public class MvcAppContext : IdentityDbContext<MvcAppUser>
{
    

    public DbSet<Post>? Posts { get; set; }

    public DbSet<Status>? Statuses { get; set; }
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
        builder.Entity<Status>().HasData(new Status { Id = 1, Name = "Draft" });
        builder.Entity<Status>().HasData(new Status { Id = 2, Name = "Waiting for approval" });
        builder.Entity<Status>().HasData(new Status { Id = 3, Name = "Published" });
        builder.Entity<Status>().HasData(new Status { Id = 4, Name = "Rejected" });
    }
}
