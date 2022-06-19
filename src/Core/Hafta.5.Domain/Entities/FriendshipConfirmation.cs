using Hafta._5.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hafta._5.Domain.Entities
{ 
    public class FriendshipConfirmation
    {
        [Key]
        public int ConfirmationID { get; set; }
        public AppUser FriendshipSenderID { get; set; }
        public AppUser FriendshipReceiverID { get; set; }
        public bool Confirmation { get; set; }
        public DateTime Date { get; set; }
    }
}
