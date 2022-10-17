using Microsoft.AspNetCore.Mvc;
using MvcApp.Services.Interfaces;

namespace MvcApp.Controllers
{
    public class PostsController : Controller
    {
        private IBlogPostService _blogPostService;

        public PostsController(IBlogPostService blogPostService)
        {
            _blogPostService=blogPostService;
        }

        public IActionResult Index()
        {
            var posts = _blogPostService.GetLastEight(); 
            return View(posts);
        }

        public IActionResult Details(int? id)
        {
            if(id== null)   
                return NotFound();

            var post = _blogPostService.GetById(id.Value);
            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}
