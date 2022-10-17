using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.Services.Interfaces;

namespace MvcApp.Services.Posts
{
    public class BasePostService :IBasePostService
    {
        protected readonly MvcAppContext _context;

        public BasePostService(MvcAppContext context)
        {
            _context = context;
        }
        public Post GetById(int id)
        {
            var post = _context.Posts.Include(p => p.Status).FirstOrDefault(p => p.Id == id);
            return post;
        }
    }
}
