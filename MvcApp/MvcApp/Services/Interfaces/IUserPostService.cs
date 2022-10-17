using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IUserPostService
    {
        List<Post> GetByAuthorId(string authorId);

        Post Details(int id);

        Post AddPost(Post post);

        Post GetById(int id);

        void EditPost(Post post);

        void Delete(Post post);

        bool PostExists(int id);
    }
}
