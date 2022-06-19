using Hafta._5.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta._5.Domain.Entities
{
    public class Post   
    {
        [Key]
        public int PostID { get; set; }
        public AppUser UserID { get; set; }
        public string PostContent { get; set; }
        public string Additional { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string PostType { get; set; }

    }

}
