using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        private ApplicationUser GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindById(userId);
            return user;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            var user = GetCurrentUser();
            return View();
        }

        public ActionResult EditUser()
        {
            var user = GetCurrentUser();
            return View(user.Id);
        }
    }
}