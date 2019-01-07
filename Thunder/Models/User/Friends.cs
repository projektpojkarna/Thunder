using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Thunder.Models
{
    public class Friends
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public List<string> FriendList {get;set;} //Lista med UserId
    }



    public class FriendsDbContext : DbContext
    {
        public DbSet<Friends> Friends { get; set; }

        public FriendsDbContext() : base("DefaultConnection") { }
    }
}