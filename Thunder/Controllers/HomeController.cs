using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;
using Thunder.Models.User;
using Thunder.Models.ViewModel;

namespace Thunder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var profiles = new ProfileDbContext().Profiles.ToList();
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}



