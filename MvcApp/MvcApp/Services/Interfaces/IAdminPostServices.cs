using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IAdminPostServices
    {
        public List<Post> GetAll();

        public Post GetById(int id);

        public void Approve(Post post);

        public void Reject(Post post);
    }
}
