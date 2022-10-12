using Microsoft.AspNetCore.Mvc;
using MvcApp.Data;

namespace MvcApp.Controllers
{
    public class PostsController : Controller
    {
        private MvcAppContext _context;

        public PostsController(MvcAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var posts=_context.Posts.Where(p=>p.StatusId==3).ToList();  
            return View(posts);
        }
    }
}
