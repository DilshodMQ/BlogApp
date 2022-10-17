using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IPostService
    {
         List<Post> GetLastEight();

        Post GetById(int id);
    }
}
