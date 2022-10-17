using MvcApp.Models;

namespace MvcApp.Services.Interfaces
{
    public interface IBasePostService
    {
        Post GetById(int id);
    }
}
