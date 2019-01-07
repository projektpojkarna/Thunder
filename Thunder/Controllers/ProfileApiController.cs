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

        private void SaveChanges(Profile p)
        {
            var ctx = new ApplicationDbContext();
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
            var userId = User.Identity.GetUserId();
            var user = manager.FindById(userId);
            user.Profile = p;
            manager.Update(user);
            ctx.SaveChanges();
        }

        [Route("profile/edit")]
        [HttpPost]
        [Authorize]
        public void EditProfile(Profile model)
        {
            var p = new Profile()
            {
                Presentation = model.Presentation,
                Occupation = model.Occupation,
                Interests = model.Interests,
                Location = model.Location,
                ImgPath = model.ImgPath
            };
            SaveChanges(p);
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
