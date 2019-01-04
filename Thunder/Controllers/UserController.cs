using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;

namespace Thunder.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext dbo = new ApplicationDbContext();
        // GET: User
        public ActionResult EditUser()
        {
            int userId = Convert.ToInt32(User.Identity.GetUserId());
            return View(dbo.Users.Find(userId));
        }
    }
}