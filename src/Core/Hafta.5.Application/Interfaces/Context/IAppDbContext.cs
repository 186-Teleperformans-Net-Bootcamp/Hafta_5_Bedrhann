using Hafta._5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<Comment> Comments { get; set; }
        DbSet<Friend> Friends { get; set; }
        DbSet<FriendshipConfirmation> FriendshipConfirmations { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<MessageHistory> MessageHistories { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostHistory> PostHistories { get; set; }
    }
}
