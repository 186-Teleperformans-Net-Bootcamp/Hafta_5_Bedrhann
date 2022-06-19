using Hafta._5.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hafta._5.Domain.Entities
{
    public class PostHistory  
    {
        [Key]
        public int HistoryPostID { get; set; }
        public Post Post { get; set; }
        public AppUser UserID { get; set; }
        public string PostContent { get; set; }
        public string Additional { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string HistoryPostType { get; set; }
    }

}
