using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Interfaces;
using NuGet.Versioning;

namespace MvcApp.Services.Posts
{
    public class BlogPostService : BasePostService, IBlogPostService
    {
        public BlogPostService(MvcAppContext context): base(context)    
        {
          
        }

        public List<Post> GetLastEight()
        {
            var posts = _context.Posts.Where(p => p.StatusId == (int)Enums.StatusesEnum.Published)
                .OrderByDescending(p => p.DateCreated).Take(8).ToList();
            return posts;
        }
    }
}
