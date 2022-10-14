using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IPostServices
    {
        public List<Post> GetLastEight();
    }
}
