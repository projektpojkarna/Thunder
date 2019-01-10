using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Thunder.Models.User
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        public string RecieverId { get; set; }
        public string SenderId { get; set; }
    }

    public class FriendRequestDbContext : DbContext
    {
        public DbSet<FriendRequest> Requests { get; set; }

        public FriendRequestDbContext() : base("DefaultConnection") { }

    }
}