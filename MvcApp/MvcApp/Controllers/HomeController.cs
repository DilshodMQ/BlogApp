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
            
            var lastEight = posts.OrderByDescending(p => p.DateCreated).Take(8);

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