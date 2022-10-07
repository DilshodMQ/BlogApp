using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;

namespace MvcApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private readonly MvcAppContext _context;

        public PostsController(MvcAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var posts=_context.Posts.Where(p=>p.StatusId == 2).ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _context.Posts.Include(p=>p.Status).FirstOrDefault(p=>p.Id == id);
            return View(post);
        }

        public IActionResult Approve(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            post.StatusId = 3;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Reject(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            
                post.StatusId = 4;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
