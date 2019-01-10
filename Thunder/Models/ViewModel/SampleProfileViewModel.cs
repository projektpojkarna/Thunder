using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Thunder.Models;
using Thunder.Models.User;

namespace Thunder.Models.ViewModel
{
    public class SampleProfileViewModel
    {
        public List<Thunder.Models.User.Image> Images { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}