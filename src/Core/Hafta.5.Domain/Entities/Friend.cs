using Hafta._5.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Domain.Entities
{
    public class Friend
    {
        [Key]
        public int FriendshipID { get; set; }
        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }
        public bool Confirmation { get; set; }
    }
}

