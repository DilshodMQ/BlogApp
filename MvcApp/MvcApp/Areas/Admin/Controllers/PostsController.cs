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
            var posts = _context.Posts.Where(p => p.StatusId !=(int) Enums.StatusesEnum.Draft).ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _context.Posts.Include(p=>p.Status).FirstOrDefault(p=>p.Id == id);
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            post.StatusId =(int) Enums.StatusesEnum.Published;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            
                post.StatusId = (int)Enums.StatusesEnum.Rejected;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
