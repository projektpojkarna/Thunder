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
    [Authorize] //Alla vyer i denna kontroller kräver inlogg
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
            var u = GetCurrentUser();
            var p = u.Profile;
            return View(new ProfileViewModel() {
                Name = string.Concat(u.FirstName, " ", u.LastName),
                Location = p.Location,
                Occupation = p.Occupation,
                Interests = p.Interests,
                Presentation = p.Presentation,
                ImgPath = p.ImgPath
            });
        }
    }
}