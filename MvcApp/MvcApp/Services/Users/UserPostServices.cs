using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;

namespace MvcApp.Services.Users
{
    public class UserPostServices
    {
        public  MvcAppContext _context;

        public  UserPostServices(MvcAppContext context)
        {
           _context = context;
        }

        public List<Post> GetByAuthorId (string authorId)
        {
            var authorPosts = _context.Posts.Include(p => p.Status).Where(p => p.AuthorId == authorId);
            return authorPosts.ToList();
        }
        public Post Details(int? id)
        {
            var post=_context.Posts.Include (p => p.Status).FirstOrDefault(p => p.Id == id);
            return post;
        }

        public Post AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges(); 
            return post;
        }
        public Post GetById(int id)
        {
            var post = _context.Posts.Find(id);
            return post;
        }

        public void EditPost(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
        public bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
