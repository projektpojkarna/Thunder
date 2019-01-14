using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Thunder.Models.User
{
    public class Image
    {   
       [Key]
        public string UserID { get; set; }
        [DisplayName("Bildtext (Frivilligt)")]
        public string Title { get; set; }
        [DisplayName("Ladda Upp Bild")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }

    public class ImageDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public ImageDbContext() : base("DefaultConnection") { }
    }
}