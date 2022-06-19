using Hafta._5.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta._5.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public AppUser SenderID { get; set; }
    }
}
