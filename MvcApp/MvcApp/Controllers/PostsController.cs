using Microsoft.AspNetCore.Mvc;
using MvcApp.Data;
using MvcApp.Services.Interfaces;

namespace MvcApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostServices _postServices;

        public PostsController(IPostServices postServices)
        {
            _postServices=postServices;
        }

        public IActionResult Index()
        {
            var posts = _postServices.GetLastEight(); 
            return View(posts);
        }
    }
}
