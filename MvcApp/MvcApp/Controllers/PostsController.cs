using Microsoft.AspNetCore.Mvc;
using MvcApp.Data;
using MvcApp.Services.Interfaces;

namespace MvcApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService=postService;
        }

        public IActionResult Index()
        {
            var posts = _postService.GetLastEight(); 
            return View(posts);
        }

        public IActionResult Details(int? id)
        {
            if(id== null)   
                return NotFound();

            var post = _postService.GetById(id.Value);
            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}
