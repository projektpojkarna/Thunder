using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Thunder.Models;
using Microsoft.AspNet.Identity;
using System.ComponentModel;

namespace Thunder.Models
{
    public class Profile
    {
        [Key]
        public string UserId { get; set; }

        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [DisplayName("Födelsedatum")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Ort")]
        public string Location { get; set; }

        [DisplayName("Sysselsättning")]
        public string Occupation { get; set; }

        [DisplayName("Presentation")]
        public string Presentation { get; set; }

        //Används ej
        public HashSet<string> Interests { get; set; }


    }

        public class ProfileDbContext : DbContext
        {
            public DbSet<Profile> Profiles { get; set; }

            public ProfileDbContext() : base("DefaultConnection") { }
        }

    
}