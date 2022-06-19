using Hafta._5.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hafta._5.Domain.Entities
{
    public class MessageHistory   
    {
        [Key]
        public int HistoryMessageID { get; set; }
        public Message Message { get; set; }
        public AppUser SenderID { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public AppUser RecipientID { get; set; }
        public string Additional { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string MessageType { get; set; }
    }

}
