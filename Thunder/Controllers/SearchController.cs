using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;

namespace Thunder.Controllers
{
    public class SearchController : Controller
    {

        private ProfileDbContext Db = new ProfileDbContext();

        public ActionResult Index(string searchString)
        {
            return View(Db.Profiles.Where(s => s.FirstName == searchString || searchString == null).ToList());
        }

    }
}