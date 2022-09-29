using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MvcApp.Areas.Identity.Data;

namespace MvcApp.Models
{
    public class Post
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Author")]
        public string? AuthorId { get; set; }
        public MvcAppUser? Author { get; set; }
       
    }
}
