using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MvcAppContext _context;

        public HomeController(ILogger<HomeController> logger, MvcAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task <IActionResult> Index()
        {

            var posts = await _context.Posts.Where(p => p.StatusId == 3).ToListAsync();
            var orderedPosts = from u in posts
                               orderby u.DateCreated descending
                               select u;
            var lastEight = orderedPosts.Take(8).ToList();
            return View(lastEight);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}