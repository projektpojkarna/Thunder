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
    public class FriendList
    {
        [Key]
        public string UserId { get; set; }

        public List<string> Friend_UserIds {get;set;} //Lista med UserId
    }



    public class FriendListDbContext : DbContext
    {
        public DbSet<FriendList> Friends { get; set; }

        public FriendListDbContext() : base("DefaultConnection") { }
    }
}