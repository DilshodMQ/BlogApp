using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Admin;
using MvcApp.Services.Interfaces;
using MvcApp.Services.Users;

namespace MvcApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private IAdminPostService _adminPostService;
        public PostsController(IAdminPostService adminPostService)
        {

            _adminPostService = adminPostService;

        }
        public IActionResult Index()
        {
            var posts = _adminPostService.GetAll();

            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _adminPostService.GetById(id);
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var post=_adminPostService.GetById(id);    
            _adminPostService.Approve(post);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var post = _adminPostService.GetById(id);
            _adminPostService.Reject(post);
            return RedirectToAction("Index");
        }
    }
}
