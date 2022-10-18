using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IUserPostService : IBasePostService
    {
        List<Post> GetByAuthorId(string authorId);

        Post Details(int id);

        Post AddPost(Post post);

        void EditPost(Post post);

        void Delete(Post post);

        bool PostExists(int id);
    }
}
