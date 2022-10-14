using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Interfaces;

namespace MvcApp.Services.Posts
{
    public class PostServices : IPostServices
    {
        private readonly MvcAppContext _context;

        public PostServices(MvcAppContext context)
        {
            _context = context;
        }
        public List<Post> GetLastEight()
        {
            var posts = _context.Posts.Where(p => p.StatusId == (int)Enums.StatusesEnum.Published)
                .OrderByDescending(p => p.DateCreated).Take(8).ToList();
            return posts;
        }
    }
}
