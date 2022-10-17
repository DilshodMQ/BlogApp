using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Interfaces;

namespace MvcApp.Services.Admin
{
    public class AdminPostService : IAdminPostService
    {
        public MvcAppContext _context;

        public AdminPostService(MvcAppContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            var posts = _context.Posts.Include(p=>p.Status).Where(p => p.StatusId != (int)Enums.StatusesEnum.Draft).ToList();
            return posts;
        }
        public Post GetById(int id)
        {
            var post = _context.Posts.Include(p => p.Status).FirstOrDefault(p => p.Id == id);
            return post;
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
