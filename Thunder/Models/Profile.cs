using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Thunder.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Presentation { get; set; }
        public HashSet<string> Interests { get; set; }
        public string Location { get; set; }
        public string Occupation { get; set; }
        public string ImgPath { get; set; }
    }
}