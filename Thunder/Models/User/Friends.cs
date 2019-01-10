using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Thunder.Models.User;

namespace Thunder.Models
{
    public class Friends
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }
        public string FriendUserId { get; set; }

        
    }



    public class FriendsDbContext : DbContext
    {
        public DbSet<Friends> Friends { get; set; }

        public FriendsDbContext() : base("DefaultConnection") { }
    }
}