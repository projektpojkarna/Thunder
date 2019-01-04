using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thunder.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        //Presentation
        //Intressen
        //Stad
        //Occupation: Jobb/studier
        //Sökväg till bild
    }
}