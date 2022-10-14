using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MvcApp.Data;
using MvcApp.Areas.Identity.Data;
using MvcApp.Services.Interfaces;
using MvcApp.Services.Admin;
using MvcApp.Services.Users;
using MvcApp.Services.Posts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MvcAppContext>(options => options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<MvcAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MvcAppContext>();
builder.Services.AddTransient<IAdminPostServices, AdminPostServices>();
builder.Services.AddTransient<IUserPostServices, UserPostServices>();
builder.Services.AddTransient<IPostServices, PostServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "MyUsersArea",
    areaName: "Users",
    pattern: "Users/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "MyAdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
