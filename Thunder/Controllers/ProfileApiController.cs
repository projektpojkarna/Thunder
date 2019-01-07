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
        [Route("profile/edit")]
        [HttpPost]
        [Authorize]
        public void EditProfile(ProfileViewModel p)
        {
            var ctx = new ProfileDbContext();
            var userId = User.Identity.GetUserId();
            var profile = ctx.Profiles.FirstOrDefault(pr => pr.UserId == userId);
            profile.Location = p.Profile.Location;
            profile.Occupation = p.Profile.Occupation;
            profile.ImgPath = p.Profile.ImgPath;
            profile.Presentation = p.Profile.Presentation;

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
                Profile = null,
                UserId = user.Id
            };

        }
    }
}
