using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Thunder.Models;

namespace Thunder.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } //Hör till en användares vägg
        public string Author_UserId { get; set; }
        public string Text { get; set; }

    }
}

public class PostDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public PostDbContext() : base("DefaultConnection") { }
}