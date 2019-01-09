using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    [Authorize] //Alla vyer i denna kontroller kräver inlogg
    public class UserController : Controller
    {

        private ProfileViewModel GetProfileViewModel(string userId)
        {
            var profileCtx = new ProfileDbContext();
            var friendCtx = new FriendListDbContext();
            var postCtx = new PostDbContext();
            var ImgCtx = new ImageDbContext();

            var image = ImgCtx.Images.FirstOrDefault(u => u.UserID == userId);

            var profile = profileCtx.Profiles.FirstOrDefault(p => p.UserId == userId);
            if(profile.Interests == null)
            {
                profile.Interests = new HashSet<string>();
            }

           var posts = postCtx.Posts.Where(po => po.UserId == userId).ToList();

            var friends = friendCtx.Friends.FirstOrDefault(u => u.UserId == userId);
            var friendList = new List<FriendViewModel>();

            if (friends != null)
            {
                foreach (var f in friends.Friend_UserIds)
                {
                    var friendProfile = profileCtx.Profiles.SingleOrDefault(p => p.UserId == f);
                    friendList.Add(FriendViewModel.FromProfile(friendProfile));
                }
            }


            return new ProfileViewModel()
            {
                Profile = profile,
                Friends = friendList,
                Posts = posts,
                Image = image
            };
        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult EditProfile()
        {
            var ctx = new ProfileDbContext();
            var userId = User.Identity.GetUserId();
            var profileViewModel = GetProfileViewModel(userId);

            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult EditProfile(ProfileViewModel p)
        {
            var ctx = new ProfileDbContext();
            var userId = User.Identity.GetUserId();
            var profile = ctx.Profiles.FirstOrDefault(pr => pr.UserId == userId);
            profile.Location = p.Profile.Location;
            profile.Occupation = p.Profile.Occupation;
            profile.Presentation = p.Profile.Presentation;
            ctx.SaveChanges();

            return RedirectToAction("ViewProfile");
        }

        [HttpGet]
        public ActionResult ViewProfile(string userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                userId = User.Identity.GetUserId();
            }
            var profileViewModel = GetProfileViewModel(userId);
            return View(profileViewModel);
        }
    }
}