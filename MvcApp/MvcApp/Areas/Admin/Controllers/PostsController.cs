using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Admin;
using MvcApp.Services.Users;

namespace MvcApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private AdminPostServices _adminPostServices;
        public PostsController(MvcAppContext context)
        {

            _adminPostServices = new AdminPostServices(context);

        }
        public IActionResult Index()
        {
            var posts = _adminPostServices.GetAll();

            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _adminPostServices.GetById(id);
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var post=_adminPostServices.GetById(id);    
            _adminPostServices.Approve(post);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var post = _adminPostServices.GetById(id);
            _adminPostServices.Reject(post);
            return RedirectToAction("Index");
        }
    }
}
