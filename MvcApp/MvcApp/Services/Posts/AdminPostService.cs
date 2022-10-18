using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Interfaces;
using MvcApp.Services.Posts;

namespace MvcApp.Services.Admin
{
    public class AdminPostService : BasePostService,IAdminPostService
    {
        public AdminPostService(MvcAppContext context):base(context)
        {
           
        }

        public List<Post> GetAll()
        {
            var posts = _context.Posts.Include(p=>p.Status).Where(p => p.StatusId != (int)Enums.StatusesEnum.Draft).ToList();
            return posts;
        }

        public void Approve(Post post)
        {
            post.StatusId = (int)Enums.StatusesEnum.Published;
            _context.SaveChanges();
        }

        public void Reject(Post post)
        {
            post.StatusId = (int)Enums.StatusesEnum.Rejected;
            _context.SaveChanges();
        }
    }
}
