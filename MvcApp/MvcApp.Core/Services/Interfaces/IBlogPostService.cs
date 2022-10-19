using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IBlogPostService : IBasePostService    
    {
         List<Post> GetLastEight();
    }
}
