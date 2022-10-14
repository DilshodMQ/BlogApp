using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IUserPostServices
    {
        public List<Post> GetByAuthorId(string authorId);

        public Post Details(int id);

        public Post AddPost(Post post);

        public Post GetById(int id);

        public void EditPost(Post post);

        public void Delete(Post post);

        public bool PostExists(int id);
    }
}
