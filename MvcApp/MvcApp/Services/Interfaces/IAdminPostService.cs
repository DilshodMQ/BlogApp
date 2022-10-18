using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IAdminPostService : IBasePostService
    {
         List<Post> GetAll();

        void Approve(Post post);

        void Reject(Post post);
    }
}
