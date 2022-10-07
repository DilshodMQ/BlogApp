using MvcApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MvcApp.Models;

namespace MvcApp.ViewModels
{
    public class PostCreateViewModel
    {
      
        public string Title { get; set; }
        public string Content { get; set; }

       


    }
}
