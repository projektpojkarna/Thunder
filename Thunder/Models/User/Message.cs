using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Thunder.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public string Author_UserId { get; set; }
        public string Text { get; set; }
    }

    public class MessageDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessageDbContext() : base("DefaultConnection") { }
    }
}