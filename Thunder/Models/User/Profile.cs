using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Thunder.Models;
using Microsoft.AspNet.Identity;

namespace Thunder.Models
{
    public class Profile
    {
        [Key]
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Location { get; set; }
        public string Occupation { get; set; }

        public string Presentation { get; set; }
        public HashSet<string> Interests { get; set; }


    }

        public class ProfileDbContext : DbContext
        {
            public DbSet<Profile> Profiles { get; set; }

            public ProfileDbContext() : base("DefaultConnection") { }
        }

    
}