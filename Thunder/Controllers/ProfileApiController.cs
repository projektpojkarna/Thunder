using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Thunder.Models;

namespace Thunder.Controllers
{
    [RoutePrefix("api/user")]
    public class ProfileApiController : ApiController
    {

        private ApplicationUser GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindById(userId);
            return user;
        }

        [Route("profile/edit")]
        [HttpGet]
        public void EditProfile(string presentation, string occupation)
        {
            var ctx = new ApplicationDbContext();
            var u = GetCurrentUser();
            var p = ctx.Profiles.Where(pr => pr.Id == u.Profile.Id);

            //Kod för att ändra i profilen här:
            //t.ex p.Presentation = presentation;

            ctx.SaveChanges();
        }

        [Route("profile/get")]
        [HttpGet]
        public ProfileViewModel GetProfile(string userId)
        {
            var ctx = new ApplicationDbContext();
            var user = ctx.Users.FirstOrDefault(u => u.Id == userId);
            return new ProfileViewModel
            {
                Profile = user.Profile,
                UserId = user.Id
            };

        }
    }
}
