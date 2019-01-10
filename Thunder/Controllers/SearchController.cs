using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;
using Thunder.Models.User;

namespace Thunder.Controllers
{
    public class SearchController : Controller
    {


        public ActionResult Index(string searchString)
        {

            var profiles = new ProfileDbContext().Profiles.Where(s => s.FirstName == searchString || searchString == null).ToList();
            var images = new ImageDbContext().Images.ToList();
            var map = new Dictionary<Profile, Image>();
            foreach (var i in images)
            {
                foreach (var p in profiles)
                {
                    if (i.UserID == p.UserId)
                    {
                        map.Add(p, i);
                    }
                }
            }
            return View(map);
         
        }

    }
}