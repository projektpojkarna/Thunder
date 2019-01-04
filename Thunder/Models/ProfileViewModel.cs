using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thunder.Models
{
    public class ProfileViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string Occupation { get; set; }
        public string Location { get; set; }
        public string ImgPath { get; set; }
        public HashSet<string> Interests { get; set; }
    }
}